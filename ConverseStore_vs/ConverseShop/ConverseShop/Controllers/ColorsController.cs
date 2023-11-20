using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;

namespace ConverseShop.Controllers
{
    public class ColorsController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Colors
        public ActionResult Index(string color, int?colorId)
        {
            mapColor map = new mapColor();
            var data = map.Index(color, colorId);
            ViewBag.color = color;
            ViewBag.colorId = colorId;
            return View(data);
        }
        public ActionResult Create()
        {
            return View(new Color());
        }
        [HttpPost]
        public ActionResult Create(Color model)
        {
            var map = new mapColor();
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

        public ActionResult Edit(int id)
        {
            var map = new mapCategory();
            var color = map.Detail(id);
            return View(color);
        }

        [HttpPost]
        public ActionResult Edit(Color model)
        {
            if (string.IsNullOrEmpty(model.ColorName) == true)
            {
                ModelState.AddModelError("", "Chưa nhập tên sản phẩm");
                return View(model);
            }

            try
            {
                var editColor = db.Colors.Find(model.ColorID);
                editColor.ColorName = model.ColorName;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Lỗi hệ thống");
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            var color = db.Colors.Find(id);
            db.Colors.Remove(color);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}   