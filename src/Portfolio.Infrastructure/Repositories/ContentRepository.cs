using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    public class ContentRepository :IContentRepository
    {
        private readonly AppDbContext _db;
        public ContentRepository(AppDbContext db) => _db = db;

        public Task<List<Content>> GetAllAsync(CancellationToken ct)
        {
            return _db.Contents.AsNoTracking().ToListAsync(ct);
        }

        public async Task AddAsync(Content entity, CancellationToken ct)
        {
            await _db.Contents.AddAsync(entity, ct);
        }


        public Task<Content?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.Contents.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(Content entity)
        {
            _db.Contents.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
