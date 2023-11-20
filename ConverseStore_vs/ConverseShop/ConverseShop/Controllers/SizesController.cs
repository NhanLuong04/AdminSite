using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;
namespace ConverseShop.Controllers
{
    public class SizesController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Sizes
        public ActionResult Index(string size, int?sizeId)
        {
            mapSize map = new mapSize();
            var data = map.Index(size,sizeId).ToList();
            ViewBag.size = size;
            ViewBag.sizeId = sizeId;
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new Size());
        }
        [HttpPost]
        public ActionResult Create(Size model)
        {
            var map = new mapSize();
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