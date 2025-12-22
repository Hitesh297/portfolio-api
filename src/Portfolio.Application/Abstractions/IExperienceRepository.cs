using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAllAsync(CancellationToken ct);
    }
}
