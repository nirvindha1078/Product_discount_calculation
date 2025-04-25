using Microsoft.Extensions.Options;
using Product_discount_calculation_task.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Product_discount_calculation_task.Services
{
    public class ProductService : IProductService
    {
        private readonly DiscountSettings _discountSettings;

        public ProductService(IOptions<DiscountSettings> discountSettings)
        {
            _discountSettings = discountSettings.Value; 
            if (_discountSettings == null)
            {
                throw new Exception("DiscountSettings is not properly configured in appsettings.json.");
            }
        }

        public List<Product> GetProductsWithDiscounts()
        {
            var products = GetAllProducts(); 

            foreach (var product in products)
            {
                decimal discountRate = GetDiscountRateForBrand(product.ProductBrand);
                product.DiscountedPrice = product.ProductPrice * (1 - discountRate);
            }

            return products;
        }

        private List<Product> GetAllProducts()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "products.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file {filePath} could not be found.");
            }

            var jsonData = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(jsonData);

            if (products == null || products.Count == 0)
            {
                throw new Exception("Deserialization resulted in an empty or null list.");
            }

            return products;
        }

        private decimal GetDiscountRateForBrand(string brand)
        {
            switch (brand)
            {
                case "Nokia":
                    return _discountSettings.Nokia;
                case "LG":
                    return _discountSettings.LG;
                case "Samsung":
                    return _discountSettings.Samsung;
                case "Sony":
                    return _discountSettings.Sony;
                case "Sewon":
                    return _discountSettings.Sewon;
                case "Philips":
                    return _discountSettings.Philips;
                case "Huawei":
                    return _discountSettings.Huawei;
                case "Motorola":
                    return _discountSettings.Motorola;
                case "Lava":
                    return _discountSettings.Lava;
                case "Xiaomi":
                    return _discountSettings.Xiaomi;
                case "HP":
                    return _discountSettings.HP;
                case "Sagem":
                    return _discountSettings.Sagem;
                case "Tel.Me.":
                    return _discountSettings.TelMe;
                case "Micromax":
                    return _discountSettings.Micromax;
                case "ZTE":
                    return _discountSettings.ZTE;
                case "Yezz":
                    return _discountSettings.Yezz;
                case "Allview":
                    return _discountSettings.Allview;
                case "Acer":
                    return _discountSettings.Acer;
                case "T-Mobile":
                    return _discountSettings.TMobile;
                case "vivo":
                    return _discountSettings.Vivo;
                case "Vodafone":
                    return _discountSettings.Vodafone;
                case "XOLO":
                    return _discountSettings.XOLO;
                case "Innostream":
                    return _discountSettings.Innostream;
                case "i-mobile":
                    return _discountSettings.IMobile;
                case "Blackview":
                    return _discountSettings.Blackview;
                case "Lenovo":
                    return _discountSettings.Lenovo;
                case "Realme":
                    return _discountSettings.Realme;
                case "Plum":
                    return _discountSettings.Plum;
                case "Maxwest":
                    return _discountSettings.Maxwest;
                case "Archos":
                    return _discountSettings.Archos;
                case "HTC":
                    return _discountSettings.HTC;
                case "Icemobile":
                    return _discountSettings.Icemobile;
                default:
                    return 0.05m;
            }
        }
    }
}
