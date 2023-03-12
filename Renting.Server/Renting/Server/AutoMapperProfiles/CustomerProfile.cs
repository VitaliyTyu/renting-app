using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>(MemberList.Destination).ReverseMap();
        }
    }
}
