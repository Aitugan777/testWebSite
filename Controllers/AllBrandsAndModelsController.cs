using Microsoft.AspNetCore.Mvc;
using TestWebSite.ContextFolder;
using TestWebSite.Models;

namespace TestWebSite.Controllers
{
    public class AllBrandsAndModelsController : Controller
    {
        public IActionResult Index()
        {
            DataContext dataContext = new DataContext();
            AllBrandsAndModels allBrandsAndModels = new AllBrandsAndModels()
            {
                Brands = dataContext.Brands.ToList(),
                Models = dataContext.Models.ToList(),
            };
            return View(allBrandsAndModels);
        }
    }
}
