using AutoMapper;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IContactFormRepository _repo;
        private readonly IMapper _mapper;

        public ContactFormService(IContactFormRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ContactFormDto>> GetAsync(CancellationToken ct)
        {
            var entities = await _repo.GetAllAsync(ct);
            var ordered = entities
                .ToList();

            return _mapper.Map<IReadOnlyList<ContactFormDto>>(ordered);
        }

        public async Task<ContactFormDto> CreateAsync(ContactFormCreateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<ContactForm>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            return _mapper.Map<ContactFormDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            return true;
        }

        public async Task<ContactFormDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<ContactFormDto>(entity);
        }

    }
}
