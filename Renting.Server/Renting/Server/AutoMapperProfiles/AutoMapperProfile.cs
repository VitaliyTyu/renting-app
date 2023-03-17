using AutoMapper;

using Renting.DAL.Entities;
using Renting.Server.Dtos;

namespace Renting.Server.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>(MemberList.Destination).ReverseMap();
            CreateMap<CountryOfOrigin, CountryOfOriginDto>(MemberList.Destination).ReverseMap();
            CreateMap<Customer, CustomerDto>(MemberList.Destination).ReverseMap();
            CreateMap<Discount, DiscountDto>(MemberList.Destination).ReverseMap();
            CreateMap<Item, ItemDto>(MemberList.Destination).ReverseMap();
            CreateMap<Penalty, PenaltyDto>(MemberList.Destination).ReverseMap();
            CreateMap<PenaltyType, PenaltyTypeDto>(MemberList.Destination).ReverseMap();
            CreateMap<Rent, RentDto>(MemberList.Destination).ReverseMap();
            CreateMap<User, UserDto>(MemberList.Destination).ReverseMap();
            CreateMap<Warehouse, WarehouseDto>(MemberList.Destination).ReverseMap();
        }
    }
}
