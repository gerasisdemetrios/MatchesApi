using Matches.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matches.Models.Dto
{
    public class MatchDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public TimeSpan MatchTime { get; set; }

        [Required]
        public string TeamA { get; set; }

        [Required]
        public string TeamB { get; set; }

        [Required]
        public Sport Sport { get; set; }

        public virtual List<MatchOddDto> MatchOdds { get; set; }

    }
}
