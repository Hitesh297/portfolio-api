using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record ExperienceDto
    {
        public long Id { get; init; }
        public string CompanyName { get; init; } = null!;
        public string Position { get; init; } = null!;
        public string Responsibilities { get; init; } = null!;
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
    }

    public record ExperienceCreateUpdateDto
    {
        public string CompanyName { get; init; } = null!;
        public string Position { get; init; } = null!;
        public string Responsibilities { get; init; } = null!;
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
    }
}
