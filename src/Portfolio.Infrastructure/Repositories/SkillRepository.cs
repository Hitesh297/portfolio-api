using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    internal class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _db;
        public SkillRepository(AppDbContext db) => _db = db;

        public Task<List<Skill>> GetAllAsync(CancellationToken ct)
        {
            return _db.Skills.AsNoTracking().ToListAsync(ct);
        }

        public async Task AddAsync(Skill entity, CancellationToken ct)
        {
            await _db.Skills.AddAsync(entity, ct);
        }


        public Task<Skill?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.Skills.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(Skill entity)
        {
            _db.Skills.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
           return _db.SaveChangesAsync(ct);
        }
    }
}
