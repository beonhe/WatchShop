using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Items()
        {
            List<Item> listItem = dbContext.Items.ToList();//database
            return View(listItem);
        }
        public ActionResult Categories()
        {
            List<Category> listCategory = dbContext.Categories.ToList();//database
            return View(listCategory);
        }
        public  ActionResult DeleteItem(int id)
        {
            Item exitstingItem = dbContext.Items.Where(temp => temp.id == id).FirstOrDefault();
            return View(exitstingItem);

        }
        [Authorize]
        [HttpPost]
        public  ActionResult DeleteItem(int id,Item item)
        {
            Item exitstingItem = dbContext.Items.Where(temp => temp.id == id).FirstOrDefault();
            dbContext.Items.Remove(exitstingItem);
            dbContext.SaveChanges();
            return RedirectToAction("Items","Admin");
        }

        public ActionResult EditItem(int? id)
        {
            var categories = dbContext.Categories.ToList();
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (Category c in categories)
            {
                categoryList.Add(new SelectListItem
                {
                    Text = c.name,
                    Value = c.id.ToString()
                });
            }
            ViewBag.Category = categoryList;

            var brands = dbContext.Brands.ToList();
            List<SelectListItem> brandList = new List<SelectListItem>();
            foreach (Brand b in brands)
            {
                brandList.Add(new SelectListItem
                {
                    Text = b.name,
                    Value = b.id.ToString()
                });
            }
            ViewBag.Brand = brandList;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = dbContext.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);

        }
        [Authorize]
        [HttpPost]
        public ActionResult EditItem([Bind(Include ="id,name,price,brandId,categoryId,image")] Item item)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(item).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Items", "Admin");
            }
            return View(item);
        }
        public ActionResult DeleteCategory(int id)
        {
            Category exitstingCategory = dbContext.Categories.Where(temp => temp.id == id).FirstOrDefault();
            return View(exitstingCategory);

        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteCategory(int id, Category category)
        {
            Category exitstingCategory = dbContext.Categories.Where(temp => temp.id == id).FirstOrDefault();
            dbContext.Categories.Remove(exitstingCategory);
            dbContext.SaveChanges();
            return RedirectToAction("Categories", "Admin");
        }

        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }
        [Authorize]
        [HttpPost]
        public ActionResult EditCategory([Bind(Include = "id,name")] Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(category).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Categories", "Admin");
            }
            return View(category);
        }
        public ActionResult Brands()
        {
            List<Brand> listBrand = dbContext.Brands.ToList();//database
            return View(listBrand);
        }
        public ActionResult DeleteBrand(int id)
        {
            Brand exitstingBrand = dbContext.Brands.Where(temp => temp.id == id).FirstOrDefault();
            return View(exitstingBrand);

        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteBrand(int id, Brand brand)
        {
            Brand exitstingBrand = dbContext.Brands.Where(temp => temp.id == id).FirstOrDefault();
            dbContext.Brands.Remove(exitstingBrand);
            dbContext.SaveChanges();
            return RedirectToAction("Brands", "Admin");
        }

        public ActionResult EditBrand(int? id)
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
        public ActionResult EditBrand([Bind(Include = "id,name")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(brand).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Brands", "Admin");
            }
            return View(brand);
        }

    }
}