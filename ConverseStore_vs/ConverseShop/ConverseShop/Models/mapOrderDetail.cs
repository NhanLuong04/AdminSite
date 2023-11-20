using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConverseShop.Models;

namespace ConverseShop.Models
{
    public class mapOrderDetail
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<OrderDetail> Index()
        {
            var data = db.OrderDetails.ToList();
            return data;
        }

        public int Create(OrderDetail model)
        {
            try
            {
                db.OrderDetails.Add(model);
                db.SaveChanges();
                return model.OrderDetailID;
            }
            catch
            {
                return 0;
            }
        }


        public OrderDetail Detail(int id)
        {
            return db.OrderDetails.Find(id);
        }
    }
}