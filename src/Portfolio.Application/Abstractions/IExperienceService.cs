using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IExperienceService
    {
        Task<IReadOnlyList<ExperienceDto>> GetAsync(CancellationToken ct);
        Task<ExperienceDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<ExperienceDto> CreateAsync(ExperienceCreateUpdateDto dto, CancellationToken ct);
        Task<bool> UpdateAsync(long id, ExperienceCreateUpdateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
