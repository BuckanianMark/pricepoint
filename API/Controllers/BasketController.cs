using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
      
    
    {
        private readonly IBasketRepository _basketrepo;
          private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketrepo,IMapper mapper)
        {
            _mapper = mapper;
            _basketrepo = basketrepo;
        }
        [HttpGet]

        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketrepo.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto,CustomerBasket>(basket);
            var updatedBasket = await _basketrepo.UpdateBasketAsync(customerBasket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketrepo.DeleteBasketAsync(id);
        }

        
    }
}