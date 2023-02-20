using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebSite.ContextFolder;
using TestWebSite.Models;
using TestWebSite.Repository;

namespace TestWebSite.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {

            return View(new DataContext().Models);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Brands = new DataContext().Brands;
            Model model = Tools.GetModel(id);
            if (model == null)
            {
                return View(new Model() { Name = "", Active = true, BrandId = 0 });
            }
            return View(model);
        }

        public IActionResult DeleteModel(int id)
        {
            using (var context = new DataContext())
            {
                context.Models.Remove(Tools.GetModel(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetDataFromViewField(int id, string modelName, bool active, int brandId)
        {
            Model model = Tools.GetModel(id);
            if (modelName != null)
            {
                using (var context = new DataContext())
                {
                    if (model == null)
                    {
                        context.Models.Add(new Model() { Name = modelName, Active = active, BrandId = brandId });
                    }
                    else
                    {
                        model.Name = modelName;
                        model.Active = active;
                        model.BrandId = brandId;
                        context.Models.Entry(model).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
            }
            return Redirect("~/");
        }
    }
}
