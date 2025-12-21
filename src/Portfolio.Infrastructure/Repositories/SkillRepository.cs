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
    }
}
