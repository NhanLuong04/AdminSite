using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class SuppliersController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Suppliers
        public ActionResult Index(string supplier, int? idSup)
        {
            mapSupplier map = new mapSupplier();
            var data = map.Index(supplier, idSup);
            ViewBag.supplier = supplier;
            ViewBag.idSup = idSup;
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new Supplier());
        }
        [HttpPost]
        public ActionResult Create(Supplier model)
        {
            var map = new mapSupplier();
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