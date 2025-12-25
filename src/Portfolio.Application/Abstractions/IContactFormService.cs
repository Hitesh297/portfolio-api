using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IContactFormService
    {
        Task<IReadOnlyList<ContactFormDto>> GetAsync(CancellationToken ct);
        Task<ContactFormDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<ContactFormDto> CreateAsync(ContactFormCreateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
