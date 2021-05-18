using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly ProductRepository repository;
        public ProductionsController(ProductRepository rep)
        {
            repository = rep; 
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Productions()
        {
            ViewBag.Products = await repository.GetProductsAsync();
            return View();
        }
    }
}
