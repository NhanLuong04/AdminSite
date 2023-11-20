using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class OrdersController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Orders
        public ActionResult Index()
        {
            mapOrder map = new mapOrder();
            var data = map.Index().ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new Order());
        }
        [HttpPost]
        public ActionResult Create(Order model)
        {
            var map = new mapOrder();
            var id = map.Create(model);
            if (id > 0)
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