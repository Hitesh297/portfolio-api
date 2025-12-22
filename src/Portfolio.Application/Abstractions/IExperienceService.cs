using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IExperienceService
    {
        Task<IReadOnlyList<ExperienceDto>> GetAsync(CancellationToken ct);
    }
}
