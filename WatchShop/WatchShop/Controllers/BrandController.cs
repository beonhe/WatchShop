using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class BrandController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Brand
        public ActionResult Index()
        {
            List<Brand> listBrand = dbContext.Brands.ToList();//database
            return View(listBrand);
        }
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            dbContext.Brands.Add(brand);
            dbContext.SaveChanges();
            //luu vao database
            return RedirectToAction("Brands", "Admin");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = dbContext.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);

        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(brand).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Brands", "Admin");
            }
            return View(brand);
        }
        public ActionResult Delete(int id)
        {
            Brand exitstingBrand = dbContext.Brands.Where(temp => temp.id == id).FirstOrDefault();
            return View(exitstingBrand);

        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, Brand brand)
        {
            Brand exitstingBrand = dbContext.Brands.Where(temp => temp.id == id).FirstOrDefault();
            dbContext.Brands.Remove(exitstingBrand);
            dbContext.SaveChanges();
            return RedirectToAction("Brands", "Admin");
        }

        public ActionResult ListBrand()
        {
            var listBrand = from Brand in dbContext.Brands select Brand;
            return PartialView(listBrand);
        }

    }
}