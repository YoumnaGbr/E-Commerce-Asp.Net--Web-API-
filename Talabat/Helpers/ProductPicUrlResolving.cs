using AutoMapper;
using Talabat.Core.Entities;
using Talabat.DTOs;

namespace Talabat.Helpers
{
    public class ProductPicUrlResolving : IValueResolver<Product, ProductToreturnsDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductPicUrlResolving(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToreturnsDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["ApiBaseUrl"]}/{source.PictureUrl}";

            return string.Empty;
        }
    }

}
