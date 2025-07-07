using Microsoft.AspNetCore.Mvc;
using RenArtStudyCase.Models;
using RenArtStudyCase.Services;

namespace RenArtStudyCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

       [HttpGet]
public async Task<IActionResult> GetProducts([FromQuery] string? sortBy)
{
    var products = await _productService.GetProductsAsync(sortBy);
    return Ok(products);
}


        [HttpGet("/products")]
        public IActionResult ProductsPage()
        {
            return View();
        }
    }
}
