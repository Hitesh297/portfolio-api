using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Dtos
{
    public record SkillDto(
    
        int Id,
        string Type,
        string Details,
        int Sequence,
        string FontAwesomeHTML
    );
}
