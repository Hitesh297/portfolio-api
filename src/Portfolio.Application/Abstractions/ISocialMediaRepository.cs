using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface ISocialMediaRepository
    {
        Task<List<SocialMedia>> GetAllAsync(CancellationToken ct);
        Task<SocialMedia?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(SocialMedia entity, CancellationToken ct);
        void Remove(SocialMedia entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
