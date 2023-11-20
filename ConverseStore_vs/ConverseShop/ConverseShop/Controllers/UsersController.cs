using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class UsersController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Users
        public ActionResult Index()
        {
            mapUser map = new mapUser();
            var data = map.Index().ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Create(User model)
        {
            var map = new mapUser();
            var id = map.Create(model);
            if (id != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi thêm dữ liệu, vui lòng thử lại");
                return View(model);
            }
        }
    }
}