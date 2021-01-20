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
    public class ProductController : ControllerBase
    {
        private readonly IAddProduct _addProduct;
        private readonly IGenerateInitialProducts _generateInitialProducts;
        private readonly IGetProduct _getProduct;
        private readonly IGetProducts _getProducts;
        private readonly IDeleteProduct _deleteProduct;
        private readonly IDeleteAllProducts _deleteAllProducts;
        private readonly IUpdateProduct _updateProduct;

        public ProductController(
            IAddProduct addProduct,
            IGenerateInitialProducts generateInitialProducts,
            IGetProduct getProduct,
            IGetProducts getProducts,
            IDeleteProduct deleteProduct,
            IUpdateProduct updateProduct,
            IDeleteAllProducts deleteAllProduct)
        {
            _addProduct = addProduct;
            _generateInitialProducts = generateInitialProducts;
            _getProduct = getProduct;
            _getProducts = getProducts;
            _deleteProduct = deleteProduct;
            _updateProduct = updateProduct;
            _deleteAllProducts = deleteAllProduct;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var _productResponse = await _getProducts.Execute();
                return Ok(_productResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            try
            {
                var _productResponse = await _getProduct.Execute(productId);
                return Ok(_productResponse);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Policy = "ADMIN")]
        [HttpPut("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                await _addProduct.Execute(product);
                return Ok($"Product {product.ProductId} added successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [Authorize(Policy = "ADMIN")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                await _updateProduct.Execute(product);
                return Ok($"Product {product.ProductId} updated successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [Authorize(Policy = "ADMIN")]
        [HttpDelete("productId")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            try
            {
                await _deleteProduct.Execute(productId);
                return Ok($"Product {productId} deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [Authorize(Policy = "ADMIN")]
        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                await _deleteAllProducts.Execute();
                return Ok("All products deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Policy = "ADMIN")]
        [HttpGet("generate")]
        public async Task<IActionResult> Generate()
        {
            try
            {
                await _generateInitialProducts.Execute();
                return Ok(StatusCode(StatusCodes.Status200OK));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
