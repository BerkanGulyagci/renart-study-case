using System.Net.Http.Json;

public class GoldService
{
    private readonly HttpClient _client;

    public GoldService(HttpClient client)
    {
        _client = client;
    }

    public async Task<double?> GetGoldPricePerGramAsync()
    {
        try
        {
            var response = await _client.GetFromJsonAsync<GoldApiResponse>("https://api.gold-api.com/price/XAU");
            if (response == null || response.price == 0)
                return null;

            // Ons → Gram çevirimi
            double pricePerGram = response.price / 31.1035;
            return Math.Round(pricePerGram, 2);
        }
        catch
        {
            return null;
        }
    }

    private class GoldApiResponse
    {
        public string? name { get; set; }
        public double price { get; set; }
        public string? symbol { get; set; }
    }
}
