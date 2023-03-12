using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class PenaltyProfile : Profile
    {
        public PenaltyProfile()
        {

            CreateMap<Penalty, PenaltyDto>(MemberList.Destination).ReverseMap();
        }
    }
}
