using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseStore.Models
{
    public class mapSupplier
    {
        public List<Supplier> DanhSach()
        {
            var db = new ConverseStoreEntities3();
            var data = db.Suppliers.ToList();
            return data;
        }
        //filter
        public List<Supplier> DanhSach(string supplier, int? idSup)
        {
            var db = new ConverseStoreEntities3();
            var dataSupplier = db.Suppliers.Where(p => p.SupName.ToLower().Contains(supplier.ToLower()) == true || string.IsNullOrEmpty(supplier)).ToList();
            var data = (from item in db.Suppliers where (item.SupName.ToLower().Contains(supplier.ToLower()) == true || string.IsNullOrEmpty(supplier)) && (idSup == null || item.SupID == idSup) select item).ToList();
            //Ascending order
            return data.OrderBy(m => m.SupName).ToList();
        } 
    }
}