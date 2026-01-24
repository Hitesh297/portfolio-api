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
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicQualificationsCacheKey = "public:Qualifications:v1";

        public QualificationService(IQualificationRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<QualificationDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicQualificationsCacheKey, out IReadOnlyList<QualificationDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
                .Select(s => _mapper.Map<QualificationDto>(s))
                .ToList()
                .AsReadOnly();

            _cache.Set(PublicQualificationsCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            });

            return dtos;
        }

        public async Task<QualificationDto> CreateAsync(QualificationCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Qualification>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicQualificationsCache();
            return _mapper.Map<QualificationDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            InvalidatePublicQualificationsCache();
            return true;
        }

        public async Task<QualificationDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<QualificationDto>(entity);
        }

        public async Task<bool> UpdateAsync(long id, QualificationCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _mapper.Map(dto, entity);

            await _repo.SaveChangesAsync(ct);
            InvalidatePublicQualificationsCache();
            return true;
        }

        private void InvalidatePublicQualificationsCache()
        {
            _cache.Remove(PublicQualificationsCacheKey);
        }
    }
}
