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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicProjectsCacheKey = "public:Projects:v1";

        public ProjectService(IProjectRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<ProjectDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicProjectsCacheKey, out IReadOnlyList<ProjectDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
                .OrderBy(s => s.Sequence)
                .Select(s => _mapper.Map<ProjectDto>(s))
                .ToList()
                .AsReadOnly();

            _cache.Set(PublicProjectsCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            });

            return dtos;
        }

        public async Task<ProjectDto> CreateAsync(ProjectCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Project>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicProjectsCache();
            return _mapper.Map<ProjectDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicProjectsCache();
            return true;
        }

        public async Task<ProjectDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<ProjectDto>(entity);
        }

        public async Task<bool> UpdateAsync(long id, ProjectCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _mapper.Map(dto, entity);

            await _repo.SaveChangesAsync(ct);
            InvalidatePublicProjectsCache();
            return true;
        }

        private void InvalidatePublicProjectsCache()
        {
            _cache.Remove(PublicProjectsCacheKey);
        }
    }
}
