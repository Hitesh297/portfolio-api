using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Skill
    {
        public long Id { get; set; }
        public required string Type { get; set; }
        public required string Details { get; set; }
        public required int Sequence { get; set; }
        public required string FontawesomeHtml { get; set; }
    }
}
