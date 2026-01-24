using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicSocialMediasCacheKey = "public:SocialMedias:v1";

        public SocialMediaService(ISocialMediaRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<SocialMediaDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicSocialMediasCacheKey, out IReadOnlyList<SocialMediaDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
                .OrderBy(s => s.Sequence)
                .Select(s => _mapper.Map<SocialMediaDto>(s))
                .ToList()
                .AsReadOnly();

            _cache.Set(PublicSocialMediasCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            });

            return dtos;
        }

        public async Task<SocialMediaDto> CreateAsync(SocialMediaCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<SocialMedia>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicSocialMediasCache();
            return _mapper.Map<SocialMediaDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicSocialMediasCache();
            return true;
        }

        public async Task<SocialMediaDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<SocialMediaDto>(entity);
        }

        public async Task<bool> UpdateAsync(long id, SocialMediaCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _mapper.Map(dto, entity);

            await _repo.SaveChangesAsync(ct);
            InvalidatePublicSocialMediasCache();
            return true;
        }

        private void InvalidatePublicSocialMediasCache()
        {
            _cache.Remove(PublicSocialMediasCacheKey);
        }

    }
}
