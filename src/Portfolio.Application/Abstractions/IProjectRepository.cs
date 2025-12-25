using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(CancellationToken ct);
        Task<Project?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(Project entity, CancellationToken ct);
        void Remove(Project entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
