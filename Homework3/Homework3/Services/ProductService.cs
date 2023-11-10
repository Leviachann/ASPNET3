namespace Homework3.Services
{
    using Homework3.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService
    {
        private static List<Product> products = new List<Product>();

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.Id = products.Count + 1; 
            products.Add(product);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Discount = updatedProduct.Discount;
                existingProduct.PictureUrl = updatedProduct.PictureUrl;
            }
        }

        public void RemoveProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }

}
