using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            string json = httpClient.GetStringAsync($"{Config.Apiurl}/getproduct/{id}").Result;

            return JsonConvert.DeserializeObject<Product>(json);
        }

        public void SaveProduct(Product product)
        {
            var r = httpClient.PostAsync(requestUri: $"{Config.Apiurl}/addproduct",
                content: new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8,
                mediaType: "application/json")).Result;     
        }

        public void DeleteProduct(int id)
        {
            var r = httpClient.DeleteAsync(requestUri: $"{Config.Apiurl}/deleteproduct/{id}").Result;
        }
    }
}
