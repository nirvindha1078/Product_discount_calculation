using Microsoft.AspNetCore.Mvc;
using Product_discount_calculation_task.Services;
using Product_discount_calculation_task.Models;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Product_discount_calculation_task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly DiscountSettings _discountSettings;

        public ProductController(IProductService productService, IOptions<DiscountSettings> discountSettings)
        {
            _productService = productService;
            _discountSettings = discountSettings.Value;
        }

        [HttpGet("products")]
        public IActionResult GetProductsWithDiscounts()
        {
           
            var products = _productService.GetProductsWithDiscounts();

            var result = products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.ProductBrand,
                p.ProductReleaseYear,
                p.ProductPrice,
                p.DiscountedPrice 
            });

            return Ok(result);
        }
    }
}
