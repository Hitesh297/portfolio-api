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

        public async Task AddAsync(ContactForm entity, CancellationToken ct)
        {
            await _db.ContactForms.AddAsync(entity, ct);
        }


        public Task<ContactForm?> GetByIdAsync(long id, CancellationToken ct)
        {
            return _db.ContactForms.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public void Remove(ContactForm entity)
        {
            _db.ContactForms.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return _db.SaveChangesAsync(ct);
        }

    }
}
