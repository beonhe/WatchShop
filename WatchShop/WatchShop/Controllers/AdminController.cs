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
            Item exitstingItem = dbContext.Items.Where(temp => item.id == id).FirstOrDefault();
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
    }
}