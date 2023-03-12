using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>(MemberList.Destination).ReverseMap();
        }
    }
}
