using Product_discount_calculation_task.Models;
using System.Collections.Generic;

namespace Product_discount_calculation_task.Services
{
    public interface IProductService
    {
        List<Product> GetProductsWithDiscounts();
    }
}
