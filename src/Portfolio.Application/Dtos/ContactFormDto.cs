using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record ContactFormDto
    {
        public long Id { get; init; }
        public string Name { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Message { get; init; } = null!;
    }

    public record ContactFormCreateDto
    {
        public long Id { get; init; }
        public string Name { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Message { get; init; } = null!;
    }
}
