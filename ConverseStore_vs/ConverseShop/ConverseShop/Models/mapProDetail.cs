using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConverseShop.Models
{
    public class mapProDetail
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<ProDetail> Index()
        {
            var data = db.ProDetails.ToList();
            return data;
        }

        public List<ProDetail> DSChiTietSanPham(int id)
        {
            var data = (from item in db.ProDetails where item.ProID == id select item).ToList();
            return data;
        }

        public int Create(ProDetail model)
        {
            try
            {
                db.ProDetails.Add(model);
                db.SaveChanges();
                return model.ProDeID;
            }
            catch
            {
                return 0;
            }
        }


        public ProDetail Detail(int id)
        {
            return db.ProDetails.Find(id);
        }
    }
}