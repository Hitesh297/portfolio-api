using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IQualificationRepository
    {
        Task<List<Qualification>> GetAllAsync(CancellationToken ct);
        Task<Qualification?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(Qualification entity, CancellationToken ct);
        void Remove(Qualification entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
