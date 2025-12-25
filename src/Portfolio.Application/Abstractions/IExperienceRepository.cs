using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAllAsync(CancellationToken ct);
        Task<Experience?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(Experience entity, CancellationToken ct);
        void Remove(Experience entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
