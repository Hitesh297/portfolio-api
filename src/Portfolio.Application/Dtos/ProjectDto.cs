using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record ProjectDto
    {
        public long Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Technologies { get; init; } = null!;
        public string GitUrl { get; init; } = null!;
        public string LiveUrl { get; init; } = null!;
        public string? Photo { get; init; }
        public int Sequence { get; init; }
    }
}
