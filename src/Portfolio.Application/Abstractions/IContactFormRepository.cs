using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IContactFormRepository
    {
        Task<List<ContactForm>> GetAllAsync(CancellationToken ct);
    }
}
