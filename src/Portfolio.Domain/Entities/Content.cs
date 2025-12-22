using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Content
    {
        public long Id { get; set; }

        public string ContentText { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
