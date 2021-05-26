using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Interface
{
    public interface IProductData
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        int SaveProduct(Product product);
        int DeleteProduct(int id);
    }
}
