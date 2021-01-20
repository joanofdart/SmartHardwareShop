using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHardwareShop.API.Infrastructure;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IGetCart _getCart;
        private readonly IAddToCart _addToCart;
        private readonly IGetAllCarts _getAllCarts;
        private readonly ICreateCart _createCart;
        private readonly ICloseCart _closeCart;
        private readonly IOpenCart _openCart;
        private readonly IDeleteFromCart _deleteFromCart;

        public CartController(
            IGetCart getCart,
            ICreateCart createCart,
            ICloseCart closeCart,
            IOpenCart openCart,
            IGetAllCarts getAllCarts,
            IAddToCart addToCart,
            IDeleteFromCart deleteFromCart)
        {
            _getCart = getCart;
            _createCart = createCart;
            _closeCart = closeCart;
            _openCart = openCart;
            _getAllCarts = getAllCarts;
            _addToCart = addToCart;
            _deleteFromCart = deleteFromCart;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCarts()
        {
            try
            {
                var _cartResponse = await _getAllCarts.Execute();
                return Ok(_cartResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartById(Guid cartId)
        {
            try
            {
                var _cartResponse = await _getCart.Execute(cartId);
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

        //[Authorize(Policy = "CUSTOMER")]
        [HttpPut("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartModel addToCartModel)
        {
            try
            {
                var _cartResponse = await _addToCart.Execute(addToCartModel.ProductId, addToCartModel.CartId);
                return Ok(_cartResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[Authorize(Policy = "CUSTOMER")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFromCart([FromBody] AddToCartModel addToCartModel)
        {
            try
            {
                var _cartResponse = await _deleteFromCart.Execute(addToCartModel.ProductId, addToCartModel.CartId);
                return Ok(_cartResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Policy = "ADMIN")]
        [HttpPut("close/{cartId}")]
        public async Task<IActionResult> CloseCart(Guid cartId)
        {
            try
            {
                await _closeCart.Execute(cartId);
                return Ok(StatusCode(StatusCodes.Status200OK));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Policy = "ADMIN")]
        [HttpPut("open/{cartId}")]
        public async Task<IActionResult> OpenCart(Guid cardId)
        {
            try
            {
                await _openCart.Execute(cardId);
                return Ok(StatusCode(StatusCodes.Status200OK));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
