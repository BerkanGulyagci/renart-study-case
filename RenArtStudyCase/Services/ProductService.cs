using System.Text.Json;
using RenArtStudyCase.Models;

namespace RenArtStudyCase.Services
{
    public class ProductService
    {
        private readonly string _jsonPath;

        public ProductService(IWebHostEnvironment env)
        {
            // /Data/products.json tam yolu
            _jsonPath = Path.Combine(env.ContentRootPath, "Data/products.json");
        }

        public List<Product> GetProducts(double goldPrice)
        {
            // JSON dosyasını oku
            var jsonData = File.ReadAllText(_jsonPath);

            // JSON'u Product listesine çevir
            var products = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();

            // Her ürün için fiyat hesapla
            foreach (var product in products)
            {
                product.Price = (product.PopularityScore + 1) * product.Weight * goldPrice;
            }

            return products;
        }
    }
}
