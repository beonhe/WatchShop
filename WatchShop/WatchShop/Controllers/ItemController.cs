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
    public class ItemController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Item
        public ActionResult Index()
        {
            List<Item> listItem = dbContext.Items.ToList();//database
            return View(listItem);
        }

        public ActionResult Create()
        {
            var categories = dbContext.Categories.ToList();
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (Category item in categories)
            {
                categoryList.Add(new SelectListItem
                {
                    Text = item.name,
                    Value = item.id.ToString()
                });
            }
            ViewBag.Category = categoryList;

            var brands = dbContext.Brands.ToList();
            List<SelectListItem> brandList = new List<SelectListItem>();
            foreach (Brand item in brands)
            {
                brandList.Add(new SelectListItem
                {
                    Text = item.name,
                    Value = item.id.ToString()
                });
            }
            ViewBag.Brand = brandList;
            return View();

        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Item item)
        {
            dbContext.Items.Add(item);
            dbContext.SaveChanges();
            //luu vao database
            return RedirectToAction("Items", "Admin");
        }

        public ActionResult Detail(int id)
        {
            Item item = dbContext.Items.Find(id);//database
            return View("Detail", item);
        }
        public ActionResult Delete(int id)
        {
            Item exitstingItem = dbContext.Items.Where(temp => temp.id == id).FirstOrDefault();
            return View(exitstingItem);

        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, Item item)
        {
            Item exitstingItem = dbContext.Items.Where(temp => temp.id == id).FirstOrDefault();
            dbContext.Items.Remove(exitstingItem);
            dbContext.SaveChanges();
            return RedirectToAction("Items", "Admin");
        }

        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "id,name,price,brandId,categoryId,image")] Item item)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(item).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Items", "Admin");
            }
            return View(item);
        }
        public ActionResult ItemByCategory(int id)
        {
            var item = from i in dbContext.Items where i.categoryId == id select i;
            return View(item);
        }
        public ActionResult ItemByBrand(int id)
        {
            var item = from i in dbContext.Items where i.brandId == id select i;
            return View(item);
        }
    }
}