using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class RentProfile : Profile
    {
        public RentProfile()
        {
            CreateMap<Rent, RentDto>(MemberList.Destination).ReverseMap();
        }
    }
}
