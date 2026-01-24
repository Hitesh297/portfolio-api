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
    public class ContactFormService : IContactFormService
    {
        private readonly IContactFormRepository _repo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string PublicContactFormsCacheKey = "public:ContactForms:v1";

        public ContactFormService(IContactFormRepository repo, IMapper mapper, IMemoryCache cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IReadOnlyList<ContactFormDto>> GetAsync(CancellationToken ct)
        {
            if (_cache.TryGetValue(PublicContactFormsCacheKey, out IReadOnlyList<ContactFormDto>? cached) && cached is not null)
                return cached;

            var entities = await _repo.GetAllAsync(ct);
            var dtos = entities
                .Select(s => _mapper.Map<ContactFormDto>(s))
                .ToList()
                .AsReadOnly();

            _cache.Set(PublicContactFormsCacheKey, dtos, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            });

            return dtos;
        }

        public async Task<ContactFormDto> CreateAsync(ContactFormCreateDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<ContactForm>(dto);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            InvalidatePublicContactFormsCache();

            return _mapper.Map<ContactFormDto>(entity);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);

            InvalidatePublicContactFormsCache();

            return true;
        }

        public async Task<ContactFormDto?> GetByIdAsync(long id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            return entity is null ? null : _mapper.Map<ContactFormDto>(entity);
        }

        private void InvalidatePublicContactFormsCache()
        {
            _cache.Remove(PublicContactFormsCacheKey);
        }

    }
}
