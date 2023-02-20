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
            Brand showBrand = brands.ToList<Brand>().Count > 0 ? brands.ToList<Brand>()[0] : new Brand();
            ViewBag.models = Tools.GetModelsBrand(showBrand.Id);
            ViewBag.brandName = showBrand.Name;
            return View(brands);
        }

        [HttpPost]
        public IActionResult Index(int brandId)
        {
            Brand showBrand = Tools.GetBrand(brandId);
            List<Brand> brands = new DataContext().Brands.ToList<Brand>();
            if (showBrand == null)
                showBrand = brands.Count > 0 ? brands[0] : new Brand();

            ViewBag.models = Tools.GetModelsBrand(showBrand.Id);
            ViewBag.brandName = showBrand.Name;
            return View(new DataContext().Brands);
        }
    }
}
