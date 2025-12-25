using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IQualificationService
    {
        Task<IReadOnlyList<QualificationDto>> GetAsync(CancellationToken ct);
        Task<QualificationDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<QualificationDto> CreateAsync(QualificationCreateUpdateDto dto, CancellationToken ct);
        Task<bool> UpdateAsync(long id, QualificationCreateUpdateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
