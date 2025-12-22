using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Project
    {
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Technologies { get; set; } = null!;

        public string GitUrl { get; set; } = null!;

        public string LiveUrl { get; set; } = null!;

        public string? Photo { get; set; }

        public int Sequence { get; set; }
    }
}
