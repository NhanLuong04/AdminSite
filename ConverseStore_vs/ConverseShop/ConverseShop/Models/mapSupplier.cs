using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapSupplier
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Supplier> Index()
        {
            var data = db.Suppliers.ToList();
            return data;
        }

        public List<Supplier> Index(string supplier, int? idSup)
        {
            var dataSupplier = db.Suppliers.Where(p => p.SupName.ToLower().Contains(supplier.ToLower()) == true || string.IsNullOrEmpty(supplier)).ToList();
            var data = (from item in db.Suppliers where (item.SupName.ToLower().Contains(supplier.ToLower()) == true || string.IsNullOrEmpty(supplier)) && (idSup == null || item.SupID == idSup) select item).ToList();
            //Ascending order
            return data.OrderBy(m => m.SupName).ToList();
        }

        public int Create(Supplier model)
        {
            try
            {
                db.Suppliers.Add(model);
                db.SaveChanges();
                return model.SupID;
            }
            catch
            {
                return 0;
            }
        }


        public Supplier Detail(int id)
        {
            return db.Suppliers.Find(id);
        }
    }
}