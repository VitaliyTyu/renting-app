using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class CountryOfOriginProfile : Profile
    {
        public CountryOfOriginProfile()
        {
            CreateMap<CountryOfOrigin, CountryOfOriginDto>(MemberList.Destination).ReverseMap();
        }
    }
}
