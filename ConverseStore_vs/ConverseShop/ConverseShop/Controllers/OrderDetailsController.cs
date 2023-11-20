using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: OrderDetails
        public ActionResult Index()
        {
            mapOrderDetail map = new mapOrderDetail();
            var data = map.Index().ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View(new OrderDetail() { Quantity = 1, UnitPrice = 0 }) ;
        }
        [HttpPost]
        public ActionResult Create(OrderDetail model)
        {
            var map = new mapOrderDetail();
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