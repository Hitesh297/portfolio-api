using AutoMapper;
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

        public SocialMediaService(ISocialMediaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SocialMediaDto>> GetAsync(CancellationToken ct)
        {
            var entities = await _repo.GetAllAsync(ct);
            var ordered = entities
                .OrderBy(s => s.Sequence)
                .ToList();

            return _mapper.Map<IReadOnlyList<SocialMediaDto>>(ordered);
        }

        public async Task<SocialMediaDto> CreateAsync(SocialMediaCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<SocialMedia>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            return _mapper.Map<SocialMediaDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
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
            return true;
        }

    }
}
