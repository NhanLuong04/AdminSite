using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class ProDetailsController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: ProDetails
        public ActionResult Index()
        {
            mapProDetail map = new mapProDetail();
            var data = map.Index().ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new ProDetail());
        }
        [HttpPost]
        public ActionResult Create(ProDetail model)
        {
            var map = new mapProDetail();
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