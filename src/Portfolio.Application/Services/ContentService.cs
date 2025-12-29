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
    public class ContentService : IContentService
    {
        private readonly IContentRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicContentsCacheKey = "public:Contents:v1";

        public ContentService(IContentRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<ContentDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicContentsCacheKey, out IReadOnlyList<ContentDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
                .Select(s => _mapper.Map<ContentDto>(s))
                .ToList()
                .AsReadOnly();

            _cache.Set(PublicContentsCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            });

            return dtos;
        }

        public async Task<ContentDto> CreateAsync(ContentCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Content>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicContentsCache();

            return _mapper.Map<ContentDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicContentsCache();
            return true;
        }

        public async Task<ContentDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<ContentDto>(entity);
        }

        public async Task<bool> UpdateAsync(long id, ContentCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _mapper.Map(dto, entity);

            await _repo.SaveChangesAsync(ct);
            InvalidatePublicContentsCache();
            return true;
        }

        private void InvalidatePublicContentsCache()
        {
            _cache.Remove(PublicContentsCacheKey);
        }
    }
}
