using Matches.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matches.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime MatchDate { get; set; }

        public TimeSpan MatchTime { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

         public Sport Sport { get; set; }

        public virtual List<MatchOdd> MatchOdds { get; set; }

    }
}
