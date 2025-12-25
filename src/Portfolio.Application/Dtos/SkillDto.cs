using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record SkillDto
    {
        public long Id { get; init; }
        public string Type { get; init; } = null!;
        public string Details { get; init; } = null!;
        public int Sequence { get; init; }
        public string FontawesomeHtml { get; init; } = null!;
    }

    public record SkillCreateUpdateDto
    {
        public string Type { get; init; } = null!;
        public string Details { get; init; } = null!;
        public int Sequence { get; init; }
        public string FontAwesomeHtml { get; init; } = null!;
    }
}
