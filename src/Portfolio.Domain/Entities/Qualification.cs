using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Qualification
    {
        public long Id { get; set; }

        public string Credential { get; set; } = null!;

        public string Details { get; set; } = null!;

        public int YearCompleted { get; set; }
    }
}
