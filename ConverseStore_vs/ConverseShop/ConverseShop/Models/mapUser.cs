using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConverseShop.Models;

namespace ConverseShop.Models
{
    public class mapUser
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        public List<User> Index()
        {
            var data = db.Users.ToList();
            return data;
        }

        public string Create(User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                return model.Username;
            }
            catch
            {
                return null;
            }
        }


        public User Detail(int id)
        {
            return db.Users.Find(id);
        }
    }
}