using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication.Entities;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Interface;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ProductionsController : Controller
    {
        private readonly IProductData repository;

        [HttpPost]
        public IActionResult Edit(Product model, IFormFile imageData)
        {
            byte[] image;
            if (ModelState.IsValid)
            {
                if (imageData != null)
                {
                    using (var binReader = new BinaryReader(imageData.OpenReadStream()))
                    {
                        image = binReader.ReadBytes((int) imageData.Length);
                    }

                    model.Image = image;
                }
                repository.SaveProduct(model);
                return RedirectToAction(nameof(ProductionsController.Index), nameof(ProductionsController).Replace("Controller",""));
            }

            return View();
        }

        public ProductionsController(IProductData rep)
        {
            repository = rep; 
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default(int) ? new Product() : repository.GetProductById(id);
            return View(entity);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction(nameof(ProductionsController.Index), nameof(ProductionsController).Replace("Controller", ""));
           
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.Products = repository.GetProducts();
            return View();
        }
    }
}
