using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IProjectService
    {
        Task<IReadOnlyList<ProjectDto>> GetAsync(CancellationToken ct);
        Task<ProjectDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<ProjectDto> CreateAsync(ProjectCreateUpdateDto dto, CancellationToken ct);
        Task<bool> UpdateAsync(long id, ProjectCreateUpdateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
