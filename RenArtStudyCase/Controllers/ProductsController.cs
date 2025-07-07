using Microsoft.AspNetCore.Mvc;
using RenArtStudyCase.Models;
using RenArtStudyCase.Services;

namespace RenArtStudyCase.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

      [HttpGet("api/products")]
public async Task<IActionResult> GetProducts([FromQuery] string? sortBy)
{
    var products = await _productService.GetProductsAsync(sortBy);
    return Ok(products);
}


        
        public IActionResult ProductsPage()
        {
            return View();
        }
    }
}
