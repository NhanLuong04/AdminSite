using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class CustomersController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Colors
        public ActionResult Index(string cusName)
        {
            mapCustomer map = new mapCustomer();
            var data = map.Index(cusName).ToList();
            ViewBag.cusName = cusName;
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost]
        public ActionResult Create(Customer model)
        {
            var map = new mapCustomer();
            var id = map.Create(model);
            if(id != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Lỗi thêm dữ liệu, vui lòng thử lại");
                return View(model);
            }
        }
    }
}