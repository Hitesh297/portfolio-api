using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync(CancellationToken ct);
        Task<Skill?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(Skill entity, CancellationToken ct);
        void Remove(Skill entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
