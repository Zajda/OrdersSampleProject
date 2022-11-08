using ApiSampleProject.Models;
using ApiSampleProject.Models.DTOs;
using AutoMapper;

namespace ApiSampleProject.Extensions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}