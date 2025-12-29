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
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicExperiencesCacheKey = "public:Experiences:v1";

        public ExperienceService(IExperienceRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<ExperienceDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicExperiencesCacheKey, out IReadOnlyList<ExperienceDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
                .Select(s => _mapper.Map<ExperienceDto>(s))
                .ToList()
                .AsReadOnly();

            _cache.Set(PublicExperiencesCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            });

            return dtos;
        }

        public async Task<ExperienceDto> CreateAsync(ExperienceCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Experience>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicExperiencesCache();
            return _mapper.Map<ExperienceDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicExperiencesCache();
            return true;
        }

        public async Task<ExperienceDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<ExperienceDto>(entity);
        }

        public async Task<bool> UpdateAsync(long id, ExperienceCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _mapper.Map(dto, entity);

            await _repo.SaveChangesAsync(ct);
            InvalidatePublicExperiencesCache();
            return true;
        }

        private void InvalidatePublicExperiencesCache()
        {
            _cache.Remove(PublicExperiencesCacheKey);
        }
    }
}
