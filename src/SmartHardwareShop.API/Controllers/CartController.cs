using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHardwareShop.API.Infrastructure;
using SmartHardwareShop.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IGetCart _getCart;
        private readonly ICreateCart _createCart;

        public CartController(IGetCart getCart, ICreateCart createCart)
        {
            _getCart = getCart;
            _createCart = createCart;
        }

        [Authorize(Policy = "ADMIN")]
        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartById(Guid cartId)
        {
            try
            {
                var _cartResponse = await _getCart.ById(cartId);
                return Ok(_cartResponse);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart()
        {
            try
            {
                var _cartResponse = await _createCart.Execute();
                return Ok(_cartResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
