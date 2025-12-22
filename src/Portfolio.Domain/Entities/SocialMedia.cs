using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class SocialMedia
    {
        public long Id { get; set; }

        public string Logo { get; set; } = null!;

        public string Url { get; set; } = null!;

        public int Sequence { get; set; }
    }
}
