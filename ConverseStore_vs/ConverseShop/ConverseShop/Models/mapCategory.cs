using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapCategory
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Category> Index()
        {
            var data = db.Categories.ToList();
            return data;
        }
        public List<Category> Index(string category, int? idCate)
        {
            var dataCategory = db.Categories.Where(p => p.NameCate.ToLower().Contains(category.ToLower()) == true || string.IsNullOrEmpty(category)).ToList();
            var data = (from item in db.Categories where (item.NameCate.ToLower().Contains(category.ToLower()) == true || string.IsNullOrEmpty(category)) && (idCate == null || item.CatID == idCate) select item).ToList();
            return data.OrderBy(m => m.NameCate).ToList();
        }

        public int Create(Category model)
        {
            try
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return model.CatID;
            }
            catch
            {
                return 0;
            }
        }


        public Category Detail(int id)
        {
            return db.Categories.Find(id);
        }
    }
}