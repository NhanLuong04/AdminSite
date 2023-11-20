using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapOrder
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<Order> Index()
        {
            var data = db.Orders.ToList();
            return data;
        }

        public int Create(Order model)
        {
            try
            {
                db.Orders.Add(model);
                db.SaveChanges();
                return model.OrderID;
            }
            catch
            {
                return 0;
            }
        }


        public Order Detail(int id)
        {
            return db.Orders.Find(id);
        }
    }
}