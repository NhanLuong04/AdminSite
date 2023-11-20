using ConverseShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ConverseShop.Controllers
{
    public class CategoriesController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Categories
        public ActionResult Index(string category, int? idCate)
        {
            mapCategory map = new mapCategory();
            var data = map.Index(category, idCate).ToList();
            ViewBag.category = category;
            ViewBag.idCate = idCate;
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            var map = new mapCategory();
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
            var cate = map.Detail(id);
            return View(cate);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (string.IsNullOrEmpty(model.NameCate) == true)
            {
                ModelState.AddModelError("", "Chưa nhập tên sản phẩm");
                return View(model);
            }

            try
            {
                var editCate = db.Categories.Find(model.CatID);
                editCate.NameCate = model.NameCate;
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
            var cate = db.Categories.Find(id);
            db.Categories.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}