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

        public async Task AddAsync(Experience entity, CancellationToken ct)
        {
            await _db.Experiences.AddAsync(entity, ct);
        }


        public Task<Experience?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.Experiences.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(Experience entity)
        {
            _db.Experiences.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
