using Matches.Data;
using Matches.Models;
using System.Threading.Tasks;

namespace Matches.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(MatchContext context) : base(context)
        {
        }
    }
}
