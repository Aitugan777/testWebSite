using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebSite.ContextFolder;
using TestWebSite.Models;
using TestWebSite.Repository;

namespace TestWebSite.Controllers
{
    public class AllBrandsAndModelsController : Controller
    {
        public IActionResult Index()
        {
            DbSet<Brand> brands = new DataContext().Brands;
            Brand showBrand = brands.ToList<Brand>()[0];
            ViewBag.models = Tools.GetModelsBrand(showBrand.Id);
            ViewBag.brandName = showBrand.Name;
            return View(brands);
        }

        [HttpPost]
        public IActionResult Index(int brandId)
        {
            Brand showBrand = Tools.GetBrand(brandId);
            if (showBrand == null)
                showBrand = new DataContext().Brands.ToList<Brand>()[0];

            ViewBag.models = Tools.GetModelsBrand(showBrand.Id);
            ViewBag.brandName = showBrand.Name;
            return View(new DataContext().Brands);
        }
    }
}
