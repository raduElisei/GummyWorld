using AutoMapper;
using GummyWorld.Domain.Entities.Dtos.Product;
using GummyWorld.Domain.Entities.Models;

namespace GummyWorld.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, AddProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
    }
}
