using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly ProductRepository repository;

        [HttpPost]
        public async Task<IActionResult> Edit(Product model, IFormFile imageData)
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
                await repository.SaveProduct(model);
                return RedirectToAction(nameof(ProductionsController.Index), nameof(ProductionsController).Replace("Controller",""));
            }

            return View();
        }

        public ProductionsController(ProductRepository rep)
        {
            repository = rep; 
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default(int) ? new Product() : repository.GetProductByIdAsync(id).Result;
            return View(entity);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await repository.DeleteProduct(id);
            return RedirectToAction(nameof(ProductionsController.Index), nameof(ProductionsController).Replace("Controller", ""));
           
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Products = await repository.GetProductsAsync();
            return View();
        }
    }
}
