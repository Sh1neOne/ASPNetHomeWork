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

        public async Task<int> Add(Product product)
        {
            context.Products.Add(product);
            return await context.SaveChangesAsync();
        } 
    }
}
