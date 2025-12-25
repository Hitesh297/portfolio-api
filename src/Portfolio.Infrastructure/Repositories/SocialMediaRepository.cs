using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    internal class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly AppDbContext _db;
        public SocialMediaRepository(AppDbContext db) => _db = db;

        public Task<List<SocialMedia>> GetAllAsync(CancellationToken ct)
        {
            return _db.SocialMedias.AsNoTracking().ToListAsync(ct);
        }

        public async Task AddAsync(SocialMedia entity, CancellationToken ct)
        {
            await _db.SocialMedias.AddAsync(entity, ct);
        }

        public Task<SocialMedia?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.SocialMedias.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(SocialMedia entity)
        {
            _db.SocialMedias.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
