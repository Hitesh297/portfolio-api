using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _db;
        public ProjectRepository(AppDbContext db) => _db = db;

        public Task<List<Project>> GetAllAsync(CancellationToken ct)
        {
            return _db.Projects.AsNoTracking().ToListAsync(ct);
        }

        public async Task AddAsync(Project entity, CancellationToken ct)
        {
            await _db.Projects.AddAsync(entity, ct);
        }


        public Task<Project?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.Projects.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(Project entity)
        {
            _db.Projects.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
