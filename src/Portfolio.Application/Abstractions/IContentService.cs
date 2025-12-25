using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IContentService
    {
        Task<IReadOnlyList<ContentDto>> GetAsync(CancellationToken ct);
        Task<ContentDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<ContentDto> CreateAsync(ContentCreateUpdateDto dto, CancellationToken ct);
        Task<bool> UpdateAsync(long id, ContentCreateUpdateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
