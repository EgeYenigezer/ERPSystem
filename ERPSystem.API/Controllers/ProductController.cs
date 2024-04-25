using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.ProductDTO;
using ERPSystem.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
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

        [HttpPost("/Products")]
        public async Task<IActionResult> GetAllAsync(ProductDTORequest productDTORequest)
        {
            var products = await _productService.GetAllAsync(productDTORequest);
            return Ok(products);
        }

        [HttpPost("/Product")]
        public async Task<IActionResult> GetAsync(ProductDTORequest productDTORequest)
        {
            var product = await _productService.GetAsync(productDTORequest);
            return Ok(product);
        }

        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddAsync(ProductDTORequest productDTORequest)
        {
            var addedProduct = await _productService.AddAsync(productDTORequest);
            return Ok($"Yeni Bir Ürün Eklendi Name:{addedProduct.Name} Id:{addedProduct.Id}");
        }

        [HttpPost("/UpdateProduct")]
        public async Task<IActionResult> UpdateAsync(ProductDTORequest productDTORequest)
        {
            await _productService.UpdateAsync(productDTORequest);
            return Ok("İşlem Sanırım Başarılı!!");
        }

        [HttpPost("/DeleteProduct")]
        public async Task<IActionResult> DeleteAsync(ProductDTORequest productDTORequest)
        {
            await _productService.DeleteAsync(productDTORequest);
            return Ok("İşlem Başarılı!!");
        }
    }
}
