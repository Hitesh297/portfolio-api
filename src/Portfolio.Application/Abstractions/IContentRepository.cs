using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IContentRepository
    {
        Task<List<Content>> GetAllAsync(CancellationToken ct);
        Task<Content?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(Content entity, CancellationToken ct);
        void Remove(Content entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
