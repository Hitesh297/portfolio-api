using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    internal class QualificationRepository : IQualificationRepository
    {
        private readonly AppDbContext _db;
        public QualificationRepository(AppDbContext db) => _db = db;

        public Task<List<Qualification>> GetAllAsync(CancellationToken ct)
        {
            return _db.Qualifications.AsNoTracking().ToListAsync(ct);
        }

        public async Task AddAsync(Qualification entity, CancellationToken ct)
        {
            await _db.Qualifications.AddAsync(entity, ct);
        }


        public Task<Qualification?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.Qualifications.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(Qualification entity)
        {
            _db.Qualifications.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
