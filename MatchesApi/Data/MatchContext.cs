using Matches.Models;
using Microsoft.EntityFrameworkCore;

namespace Matches.Data
{
    public class MatchContext : DbContext
    {

        public MatchContext(DbContextOptions<MatchContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdd> MatchOdds { get; set; }

    }
}
