using AutoMapper;
using DemoWebApiWithEfCoreAndGraphQl.Data.Entities;

namespace DemoWebApiWithEfCoreAndGraphQl.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Order, Models.OrderDto>();
        CreateMap<Address, Models.AddressDto>();
        CreateMap<Customer, Models.CustomerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                $"{src.FirstName} {src.LastName}"));
    }
}