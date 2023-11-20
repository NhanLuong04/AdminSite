using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Converse.Models
{
    public class mapProduct
    {
        public List<Product> Index()
        {
            var db = new ConverseStoreEntities();
            var data = db.Products.ToList();
            return data;
        }
        public List<Product> Index(string product, int? idPro)
        {
            var db = new ConverseStoreEntities();
            var dataProduct = db.Products.Where(p => p.ProName.ToLower().Contains(product.ToLower()) == true || string.IsNullOrEmpty(product)).ToList();
            var data = (from item in db.Products where (item.ProName.ToLower().Contains(product.ToLower()) == true || string.IsNullOrEmpty(product)) && (idPro == null || item.ProID == idPro) select item).ToList();
            return data.OrderBy(m => m.ProName).ToList();
        }
    }
}