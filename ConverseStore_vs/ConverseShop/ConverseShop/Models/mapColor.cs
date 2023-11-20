using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapColor
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Color> Index()
        {
            var data = db.Colors.ToList();
            return data;
        }
        public List<Color> Index(string color, int? colorId)
        {
            var dataColor = db.Colors.Where(p => p.ColorName.ToLower().Contains(color.ToLower()) == true || string.IsNullOrEmpty(color)).ToList();
            var data = (from item in db.Colors where (item.ColorName.ToLower().Contains(color.ToLower()) == true || string.IsNullOrEmpty(color)) && (colorId == null || item.ColorID == colorId) select item).ToList();
            return data.OrderBy(m => m.ColorName).ToList();
        }
        public int Create(Color model)
        {
            try
            {
                db.Colors.Add(model);
                db.SaveChanges();
                return model.ColorID;
            }
            catch
            {
                return 0;
            }
        }


        public Color Detail(int id)
        {
            return db.Colors.Find(id);
        }
    }
}