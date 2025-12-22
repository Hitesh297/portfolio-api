using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(CancellationToken ct);
    }
}
