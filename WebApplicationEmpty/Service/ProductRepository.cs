using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Interface;

namespace WebApplication.Entities
{
    public class ProductRepository : IProductData
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SaveProduct(Product product)
        {
            context.Entry(product).State = product.Id == default ? EntityState.Added : EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            context.Products.Remove(new Product() {Id = id});
            context.SaveChanges();
        }
    }
}
