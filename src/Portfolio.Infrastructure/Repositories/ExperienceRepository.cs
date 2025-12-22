using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    internal class ExperienceRepository: IExperienceRepository
    {
        private readonly AppDbContext _db;
        public ExperienceRepository(AppDbContext db) => _db = db;

        public Task<List<Experience>> GetAllAsync(CancellationToken ct)
        {
            return _db.Experiences.AsNoTracking().ToListAsync(ct);
        }
    }
}
