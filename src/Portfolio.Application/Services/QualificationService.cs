using AutoMapper;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
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
    }
}
