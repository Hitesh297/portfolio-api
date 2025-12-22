using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record SocialMediaDto
    {
        public long Id { get; init; }
        public string Logo { get; init; } = null!;
        public string Url { get; init; } = null!;
        public int Sequence { get; init; }
    }
}
