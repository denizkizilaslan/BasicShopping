using BasicShopping.DataAccess.Redis.Abstract;
using BasicShopping.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository repository;

        public BasketController(
            IBasketRepository repository)
        {
            this.repository = repository;
        }

        [Route("additem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<ActionResult> AddItemToBasket([FromBody] BasketItem basketItem)
        {
            var userId = basketItem.CustomerId;

            var basket = await repository.GetBasketAsync(userId);

            if (basket == null)
            {
                basket = new CustomerBasket(userId);
            }

            basket.Items.Add(basketItem);

            await repository.UpdateBasketAsync(basket);

            return Ok();
        }



        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(string customerId)
        {
            var basket = await repository.GetBasketAsync(customerId);

            return Ok(basket ?? new CustomerBasket(customerId));
        }
     
    }
}

