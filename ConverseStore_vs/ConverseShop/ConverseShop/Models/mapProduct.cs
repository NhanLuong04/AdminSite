using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConverseShop.Models;

namespace ConverseShop.Models
{
    public class mapProduct
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Product> Index()
        {
            var data = db.Products.ToList();
            return data;
        }
        public List<Product> Index(string product, int? idPro)
        {
            var dataProduct = db.Products.Where(p => p.ProName.ToLower().Contains(product.ToLower()) == true || string.IsNullOrEmpty(product)).ToList();
            var data = (from item in db.Products where (item.ProName.ToLower().Contains(product.ToLower()) == true || string.IsNullOrEmpty(product)) && (idPro == null || item.ProID == idPro) select item).ToList();
            return data.OrderBy(m => m.ProName).ToList();
        }

        public Product Detail(int id)
        {
            return db.Products.Find(id);
        }
    }
}