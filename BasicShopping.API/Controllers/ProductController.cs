using BasicShopping.Business.Abstract;
using BasicShopping.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Product data)
        {
            var result = await _productService.AddAsync(data);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.Get();
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result.ToList());
        }


    }
}
