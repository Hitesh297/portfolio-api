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
    }
}
