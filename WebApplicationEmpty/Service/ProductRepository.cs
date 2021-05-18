using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Entities
{
    public class ProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveProduct(Product product)
        {
            context.Entry(product).State = product.Id == default ? EntityState.Added : EntityState.Modified;

            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int id)
        {
            context.Products.Remove(new Product() {Id = id});
            return await context.SaveChangesAsync();
        }
    }
}
