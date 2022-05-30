using Domain.DTO;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("Product/{Id}")]
        public async Task<IActionResult> GetProduct(string Id)
        {
            return Ok(await _productService.GetProductByIdAsync(Id));
        }

        [HttpPost("Product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            await _productService.CreateProductAsync(productDto);
            return Ok();
        }

        [HttpPut("Product")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            return Ok(await _productService.UpdateProductAsync(productDto););
        }

        [HttpDelete("Product")]
        public async Task<IActionResult> RemoveProduct([FromBody] ProductDto productDto)
        {
            await _productService.DeleteProductAsync(productDto);
            return Ok();
        }
    }
}
