using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record QualificationDto
    {
        public long Id { get; init; }
        public string Credential { get; init; } = null!;
        public string Details { get; init; } = null!;
        public int YearCompleted { get; init; }
    }
}
