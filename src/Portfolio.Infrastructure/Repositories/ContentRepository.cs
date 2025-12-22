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
    }
}
