using AutoMapper;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProjectDto>> GetAsync(CancellationToken ct)
        {
            var entities = await _repo.GetAllAsync(ct);
            var ordered = entities
                .OrderBy(s => s.Sequence)
                .ToList();

            return _mapper.Map<IReadOnlyList<ProjectDto>>(ordered);
        }
    }
}
