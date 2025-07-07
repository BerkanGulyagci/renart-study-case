using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("popularityScore")]
    public double PopularityScore { get; set; }

    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    [JsonPropertyName("images")]
    public ProductImages? Images { get; set; }

    public double Price { get; set; } 
}

public class ProductImages
{
    [JsonPropertyName("yellow")]
    public string? Yellow { get; set; }

    [JsonPropertyName("rose")]
    public string? Rose { get; set; }

    [JsonPropertyName("white")]
    public string? White { get; set; }
}
