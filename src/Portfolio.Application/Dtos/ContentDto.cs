using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record ContentDto
    {
        public long Id { get; init; }
        public string Content { get; init; } = null!;
        public string Type { get; init; } = null!;
    }
}
