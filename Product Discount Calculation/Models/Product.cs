﻿using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("product_brand")]
    public string ProductBrand { get; set; }

    [JsonPropertyName("product_release_year")]
    public int ProductReleaseYear { get; set; }

    [JsonPropertyName("product_price")]
    public decimal ProductPrice { get; set; }

    public decimal DiscountedPrice { get; set; }
}
