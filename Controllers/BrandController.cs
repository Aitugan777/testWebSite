using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TestWebSite.ContextFolder;
using TestWebSite.Models;
using TestWebSite.Repository;

namespace TestWebSite.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View(new DataContext().Brands);
        }

        public IActionResult Edit(int id)
        {
            Brand brand = Tools.GetBrand(id);
            if (brand == null)
            {
                return View(new Brand() { Name = "Марка", Active = true });
            }
            return View(brand);
        }

        public IActionResult DeleteBrand(int id)
        {
            using (var context = new DataContext())
            {
                context.Brands.Remove(Tools.GetBrand(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetDataFromViewField(int id, string brandName, bool active)
        {
            Brand brand = Tools.GetBrand(id);
            if (brandName != null)
            {
                using (var context = new DataContext())
                {
                    if (brand == null)
                    {
                        context.Brands.Add(new Brand() { Name = brandName, Active = active });
                    }
                    else
                    {
                        brand.Name = brandName;
                        brand.Active = active;
                        context.Brands.Entry(brand).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
            }
            return Redirect("~/");
        }

    }
}
