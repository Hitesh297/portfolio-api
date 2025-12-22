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
    }
}
