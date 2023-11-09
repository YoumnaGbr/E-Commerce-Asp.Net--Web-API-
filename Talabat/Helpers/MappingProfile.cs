using AutoMapper;
using Talabat.Core.Entities;
using Talabat.DTOs;

namespace Talabat.Helpers
{
    public class MappingProfile : Profile
    {
        //private readonly IConfiguration configuration;

        public MappingProfile()
        {
            CreateMap<Product, ProductToreturnsDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, O => O.MapFrom(s => s.Category.Name))
                //.ForMember(d => d.PictureUrl, O => O.MapFrom(s => $"{configuration["ApiBaseUrl"]}/{s.PictureUrl}"));
                .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPicUrlResolving>());

            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>(); 
        }
    }
}
