using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Repositories
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly AppDbContext _db;
        public ContactFormRepository(AppDbContext db) => _db = db;

        public Task<List<ContactForm>> GetAllAsync(CancellationToken ct)
        {
            return _db.ContactForms.AsNoTracking().ToListAsync(ct);
        }

    }
}
