using OnlineMarket.Api.Interface;
using OnlineMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Api.Service
{
    public class Seeder : ISeeder
    {

        private List<Product> _products = new List<Product>();

        public bool AddProduct(Product product)
        {
            _products.Add(product);
            if (product == null)
            {
                return false;
            }
            _products.Remove(product);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product =  _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;
            _products.Remove(product); 
            return true;
        }

        public List<Product> GetAllProducts()
        {
            var product1 = new Product
            {
                Id = 1,
                Name = "Milo",
                Description = "Nourishing Drink",
                Price = 34.89f
            };
            _products.Add(product1);
            
            var product2 = new Product
            {
                Id = 2,
                Name = "Ovaltine",
                Description = "Creamy Drink",
                Price = 26.37f
            };
            _products.Add(product2);

            return _products; 
        }

        public bool UpdateProduct(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                _products.Add(updatedProduct);
                return true;
            }
            return false;
        }
    }
}
