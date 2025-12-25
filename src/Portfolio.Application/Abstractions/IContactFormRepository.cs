using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IContactFormRepository
    {
        Task<List<ContactForm>> GetAllAsync(CancellationToken ct);
        Task<ContactForm?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(ContactForm entity, CancellationToken ct);
        void Remove(ContactForm entity);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
