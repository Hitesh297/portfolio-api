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
    }
}
