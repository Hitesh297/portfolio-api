using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Portfolio.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicSkillsCacheKey = "public:skills:v1";
        public SkillService(ISkillRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<SkillDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicSkillsCacheKey, out IReadOnlyList<SkillDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
            .OrderBy(s => s.Sequence)
            .Select(s => _mapper.Map<SkillDto>(s))
            .ToList()
            .AsReadOnly();

            _cache.Set(PublicSkillsCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            });

            return dtos;
        }

        public async Task<SkillDto> CreateAsync(SkillCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Skill>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            InvalidatePublicSkillsCache(); // invalidate after write

            return _mapper.Map<SkillDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicSkillsCache(); // invalidate after delete
            return true;
        }

        public async Task<SkillDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<SkillDto>(entity);
        }

        public async Task<bool> UpdateAsync(long id, SkillCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _mapper.Map(dto, entity);

            await _repo.SaveChangesAsync(ct);
            InvalidatePublicSkillsCache(); // invalidate after update
            return true;
        }

        private void InvalidatePublicSkillsCache()
        {
            _cache.Remove(PublicSkillsCacheKey);
        }
    }
}
