using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapSize
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Size> Index()
        {
            var data = db.Sizes.ToList();
            return data;
        }
        public List<Size> Index(string size, int? sizeId)
        {
            var dataSize = db.Sizes.Where(p => p.SizeNum.ToLower().Contains(size.ToLower()) == true || string.IsNullOrEmpty(size)).ToList();
            var data = (from item in db.Sizes where (item.SizeNum.ToLower().Contains(size.ToLower()) == true || string.IsNullOrEmpty(size)) && (sizeId == null || item.SizeID == sizeId) select item).ToList();
            return data.OrderBy(m => m.SizeNum).ToList();
        }

        public int Create(Size model)
        {
            try
            {
                db.Sizes.Add(model);
                db.SaveChanges();
                return model.SizeID;
            }
            catch
            {
                return 0;
            }
        }


        public Size Detail(int id)
        {
            return db.Sizes.Find(id);
        }
    }
}