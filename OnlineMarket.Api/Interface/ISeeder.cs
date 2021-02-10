using OnlineMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Api.Interface
{
    public interface ISeeder
    {
        List<Product> GetAllProducts();
        bool AddProduct(Product product);
        bool UpdateProduct(int id, Product updatedProduct);
        bool DeleteProduct(int id);
        
    }
}
