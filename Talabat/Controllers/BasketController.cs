using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.DTOs;
using Talabat.Errors;

namespace Talabat.Controllers
{
  
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper) 
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket (string id)
        {
            var basket = await _basketRepository.GetBasketAsync (id);
            return Ok(basket ?? new CustomerBasket (id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var mappedBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);

            var CreatedOrUpdatedBasket = await _basketRepository.UpdateBasketAsync (mappedBasket);
            if (CreatedOrUpdatedBasket is null)
                return BadRequest(new ApiResponse(400));
            return Ok(CreatedOrUpdatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasketAsync (id);
        }

    }
}
