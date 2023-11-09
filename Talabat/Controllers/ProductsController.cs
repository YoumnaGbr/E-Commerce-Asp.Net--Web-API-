using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specfications;
using Talabat.Core.Specfications.ProductsSpec;
using Talabat.DTOs;
using Talabat.Errors;
using Talabat.Helpers;

namespace Talabat.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenaricRepository<Product> _productRepo;
        private readonly IGenaricRepository<ProductBrand> _brandsRepo;
        private readonly IGenaricRepository<ProductCategory> _categoriesRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenaricRepository<Product> productRepo,
            IGenaricRepository<ProductBrand> brandsRepo,
            IGenaricRepository<ProductCategory> categoriesRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _brandsRepo = brandsRepo;
            _categoriesRepo = categoriesRepo;
            _mapper = mapper;
        }
         
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToreturnsDto>>> GetProducts(string sort)
        {
            var spec = new ProductWithBrandAndCategorySpec(sort);

            var products = await _productRepo.GetAllWithSpecAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IEnumerable<ProductToreturnsDto>>(products));
        }

        [ProducesResponseType(typeof(ProductToreturnsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToreturnsDto>> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndCategorySpec(id);


            var product = await _productRepo.GetWithSpec(spec);

            if (product == null)
                return NotFound(new ApiResponse(404));
            

            return Ok(_mapper.Map<Product, ProductToreturnsDto>(product));
        }
        
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _brandsRepo.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategories()
        {
            var categories = await _categoriesRepo.GetAllAsync();
            return Ok(categories);
        }


    }
}
