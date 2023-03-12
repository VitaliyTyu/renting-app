using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class PenaltyTypeProfile : Profile
    {
        public PenaltyTypeProfile()
        {
            CreateMap<PenaltyType, PenaltyTypeDto>(MemberList.Destination).ReverseMap();
        }
    }
}
