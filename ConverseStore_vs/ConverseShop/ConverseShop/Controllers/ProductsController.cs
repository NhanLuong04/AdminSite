using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConverseShop.Models;
using System.IO;

namespace ConverseShop.Controllers
{
    public class ProductsController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();
        // GET: Products
        public ActionResult Index(string product, int? idPro)
        {
            mapProduct map = new mapProduct();
            var data = map.Index(product, idPro);
            ViewBag.product = product;
            ViewBag.idPro = idPro;
            return View(data);
        }

        public ActionResult Create()
        {
            return View(new Product() {CreatedDate = DateTime.Now });
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProID,ProName,CatID,ProImage,ProImageHover,NameDecription,CreatedDate,RemainQuantity,SoldQuantity,DISCOUNT," + "UploadImage, UploadImageHover")] Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.UploadImage == null || model.UploadImageHover == null)
                {
                    ViewBag.error = "Please select a image!!";
                }
                else
                {
                    if (model.UploadImage != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(model.UploadImage.FileName);
                        model.ProImage = path + filename;
                        model.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (model.UploadImageHover != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(model.UploadImageHover.FileName);
                        model.ProImageHover = path + filename;
                        model.UploadImageHover.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    model.CreatedDate = DateTime.Today;
                    db.Products.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Lỗi thêm dữ liệu, vui lòng thử lại");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var map = new mapProduct();
            var product = map.Detail(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if(string.IsNullOrEmpty(model.ProName) == true)
            {
                ModelState.AddModelError("", "Chưa nhập tên sản phẩm");
                return View(model);
            }

            try
            {
                var editProduct = db.Products.Find(model.ProID);
                editProduct.CreatedDate = model.CreatedDate;
                editProduct.NameDecription = model.NameDecription;
                editProduct.ProName = model.ProName;
                editProduct.ProImage = model.ProImage;
                editProduct.ProImageHover = model.ProImageHover;
                editProduct.RemainQuantity = model.RemainQuantity;
                editProduct.SoldQuantity = model.SoldQuantity;
                editProduct.DISCOUNT = model.DISCOUNT;
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
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        public ActionResult DetailProduct(int id)
        {
            return View(new ProDetail() { ProID = id });
        }

        [HttpPost]
        public ActionResult DetailProduct(ProDetail model)
        {
            db.ProDetails.Add(model);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = model.ProID });
        }
    }
}