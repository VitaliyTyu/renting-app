using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, DiscountDto>(MemberList.Destination).ReverseMap();
        }
    }
}
