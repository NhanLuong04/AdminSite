﻿using ConverseStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Data.Entity;

namespace ConverseStore.Controllers
{
    public class ProductController : Controller
    {
        private ConverseStoreEntities3 db = new ConverseStoreEntities3();
        // GET: Product
        public ActionResult DanhSach(string product, int?idPro)
        {
            mapProduct map = new mapProduct();
            var data = map.DanhSach(product, idPro);
            ViewBag.product = product;
            ViewBag.idPro = idPro;
            return View(data);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,ProName,CatID,ProImage,ProImageHover,NameDecription,CreatedDate," + "UploadImage, UploadImageHover")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage == null || product.UploadImageHover == null)
                {
                    ViewBag.error = "Please select a image!!";
                }
                else
                {
                    if (product.UploadImage != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(product.UploadImage.FileName);
                        product.ProImage = path + filename;
                        product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (product.UploadImageHover != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(product.UploadImageHover.FileName);
                        product.ProImageHover = path + filename;
                        product.UploadImageHover.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    product.CreatedDate = DateTime.Today;
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("DanhSach");
                }
            }

            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,ProName,CatID,ProImage,ProImageHover,NameDecription,CreatedDate," + "UploadImage, UploadImageHover")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage == null || product.UploadImageHover == null)
                {
                    ViewBag.error = "Please select a image!!";
                }
                else
                {
                    if (product.UploadImage != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(product.UploadImage.FileName);
                        product.ProImage = path + filename;
                        product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (product.UploadImageHover != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(product.UploadImageHover.FileName);
                        product.ProImageHover = path + filename;
                        product.UploadImageHover.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }

                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DanhSach");
                }
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        // GET: ProDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}