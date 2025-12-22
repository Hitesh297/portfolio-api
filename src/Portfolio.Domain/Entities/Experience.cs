using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Entities
{
    public class Experience
    {
        public long Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string Responsibilities { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }
    }
}
