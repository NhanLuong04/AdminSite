using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseStore.Models
{
    public class mapCategory
    {
        public List<Category> DanhSach()
        {
            var db = new ConverseStoreEntities3();
            var data = db.Categories.ToList();
            return data;
        }
        public List<Category> DanhSach(string category, int? idCate)
        {
            var db = new ConverseStoreEntities3();
            var dataCategory = db.Categories.Where(p => p.NameCate.ToLower().Contains(category.ToLower()) == true || string.IsNullOrEmpty(category)).ToList();
            var data = (from item in db.Categories where (item.NameCate.ToLower().Contains(category.ToLower()) == true || string.IsNullOrEmpty(category)) && (idCate ==null || item.CatID == idCate) select item).ToList();
            return data.OrderBy(m => m.NameCate).ToList();
        }
    }
}