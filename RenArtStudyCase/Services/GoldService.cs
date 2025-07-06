using System.Net.Http.Json;

public class GoldService
{
    private readonly HttpClient _client;

    public GoldService(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Add("x-access-token", "goldapi-fmousmcs7p4z4-io");
    }

    public async Task<double?> GetGoldPricePerGramAsync()
    {
        try
        {
            var response = await _client.GetFromJsonAsync<GoldApiResponse>("https://www.goldapi.io/api/XAU/USD");
            if (response == null || response.price_gram_24k == 0)
                return null;

            return Math.Round(response.price_gram_24k, 2);
        }
        catch
        {
            return null;
        }
    }

    private class GoldApiResponse
    {
        public double price_gram_24k { get; set; }
    }
}
