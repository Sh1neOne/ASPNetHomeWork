using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication.Entities;
using WebApplication.Interface;

namespace WebApplication.Service
{
    public class ProductRerositoryApi : IProductData
    {

        private HttpClient httpClient;

        public ProductRerositoryApi()
        {
            this.httpClient = new HttpClient(); 
        }

        public List<Product> GetProducts()
        {
           
            string json = httpClient.GetStringAsync($"{Config.Apiurl}/getproducts").Result;
 
            return JsonConvert.DeserializeObject<List<Product>>(json);

        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public int DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
