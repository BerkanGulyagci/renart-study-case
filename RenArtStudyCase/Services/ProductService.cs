    using System.Text.Json;
    using RenArtStudyCase.Models;

    namespace RenArtStudyCase.Services
    {
        public class ProductService
        {
            private readonly string _jsonPath;
            private readonly GoldService _goldService;

            public ProductService(IWebHostEnvironment env, GoldService goldService)
            {
                _jsonPath = Path.Combine(env.ContentRootPath, "Data/products.json");
                _goldService = goldService;
            }

        public async Task<List<Product>> GetProductsAsync()
        {
            double goldPrice = await _goldService.GetGoldPricePerGramAsync() ?? 70.0;
            Console.WriteLine($"Gold price from API: {goldPrice}");


            var jsonData = File.ReadAllText(_jsonPath);
            var products = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();

            foreach (var product in products)
            {
                product.Price = (product.PopularityScore + 1) * product.Weight * goldPrice;
            }

            return products;
        }

    }
}
