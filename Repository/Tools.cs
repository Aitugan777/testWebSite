using TestWebSite.ContextFolder;
using TestWebSite.Models;

namespace TestWebSite.Repository
{
    public static class Tools
    {

        public static Brand GetBrand(int id)
        {
            foreach (Brand brand in new DataContext().Brands)
                if (brand.Id == id)
                    return brand;
            return null;
        }
        
        public static Model GetModel(int id)
        {
            foreach (Model model in new DataContext().Models)
                if (model.Id == id)
                    return model;
            return null;
        }

        public static List<Model> GetModelsBrand(int brandId)
        {
            List<Model> list = new List<Model>();
            foreach (Model model in new DataContext().Models)
                if (model.BrandId == brandId)
                    list.Add(model);
            return list;
        }

    }
}
