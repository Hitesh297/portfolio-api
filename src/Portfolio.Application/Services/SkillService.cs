using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repo;

        public SkillService(ISkillRepository repo) => _repo = repo;
        public async Task<List<SkillDto>> GetAsync(CancellationToken ct)
        => (await _repo.GetAllAsync(ct))
            .OrderBy(s => s.Sequence)
            .Select(ToDto).ToList();

        private static SkillDto ToDto(Skill s) =>
        new(s.Id, s.Type, s.Details, s.Sequence, s.FontAwesomeHTML);
    }
}
