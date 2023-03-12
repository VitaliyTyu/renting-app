using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(MemberList.Destination).ReverseMap();
        }
    }
}
