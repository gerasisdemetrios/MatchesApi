using AutoMapper;
using Matches.Models;
using Matches.Models.Dto;

namespace Matches.Data
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>().ForMember(dest => dest.MatchOdds, src => src.MapFrom( x => x.MatchOdds))
                .ReverseMap();

            CreateMap<MatchOdd, MatchOddDto>()
                .ReverseMap();
        }
    }
}
