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
    }
}
