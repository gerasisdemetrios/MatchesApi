namespace Matches.Models.Dto
{
    public class MatchOddDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string Specifier { get; set; }
        public double Odd { get; set; }

    }
}
