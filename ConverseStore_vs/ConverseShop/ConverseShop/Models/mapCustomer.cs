using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapCustomer
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Customer> Index()
        {
            var data = db.Customers.ToList();
            return data;
        }
        public List<Customer> Index(string cusName)
        {
            var dataCategory = db.Customers.Where(p => p.CusName.ToLower().Contains(cusName.ToLower()) == true || string.IsNullOrEmpty(cusName)).ToList();
            return dataCategory.OrderBy(m => m.CusName).ToList();
        }

        public string Create(Customer model)
        {
            try
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return model.CusPhone;
            }
            catch
            {
                return null;
            }
        }


        public Customer Detail(int id)
        {
            return db.Customers.Find(id);
        }
    }
}