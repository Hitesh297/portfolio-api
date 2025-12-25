using AutoMapper;
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

        public QualificationService(IQualificationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<QualificationDto>> GetAsync(CancellationToken ct)
        {
            var entities = await _repo.GetAllAsync(ct);
            var ordered = entities
                .ToList();

            return _mapper.Map<IReadOnlyList<QualificationDto>>(ordered);
        }

        public async Task<QualificationDto> CreateAsync(QualificationCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Qualification>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            return _mapper.Map<QualificationDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
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
            return true;
        }
    }
}
