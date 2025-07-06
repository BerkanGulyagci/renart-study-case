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
        public IActionResult GetProducts()
        {
            // Şimdilik sabit altın fiyatı: 70 USD/gr
            double goldPrice = 70.0;

            var products = _productService.GetProducts(goldPrice);

            return Ok(products);
        }

        [HttpGet("/products")]
        public IActionResult ProductsPage()
        {
            return View();
        }
                













    }
}
