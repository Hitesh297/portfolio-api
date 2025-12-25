using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface ISkillService
    {
        Task<IReadOnlyList<SkillDto>> GetAsync(CancellationToken ct);
        Task<SkillDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<SkillDto> CreateAsync(SkillCreateUpdateDto dto, CancellationToken ct);
        Task<bool> UpdateAsync(long id, SkillCreateUpdateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
