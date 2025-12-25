using AutoMapper;
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

        public ContentService(IContentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ContentDto>> GetAsync(CancellationToken ct)
        {
            var entities = await _repo.GetAllAsync(ct);
            var ordered = entities
                .ToList();

            return _mapper.Map<IReadOnlyList<ContentDto>>(ordered);
        }

        public async Task<ContentDto> CreateAsync(ContentCreateUpdateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<Content>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            return _mapper.Map<ContentDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
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
            return true;
        }
    }
}
