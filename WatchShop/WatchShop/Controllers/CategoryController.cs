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
    public class CategoryController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index()
        {
            List<Category> listCategory = dbContext.Categories.ToList();//database
            return View(listCategory);
        }
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            //luu vao database
            return RedirectToAction("Categories", "Admin");
        }
        public ActionResult Delete(int id)
        {
            Category exitstingCategory = dbContext.Categories.Where(temp => temp.id == id).FirstOrDefault();
            return View(exitstingCategory);

        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            Category exitstingCategory = dbContext.Categories.Where(temp => temp.id == id).FirstOrDefault();
            dbContext.Categories.Remove(exitstingCategory);
            dbContext.SaveChanges();
            return RedirectToAction("Categories", "Admin");
        }

        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "id,name")] Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(category).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Categories", "Admin");
            }
            return View(category);
        }
        public ActionResult ListCategory()
        {
            var listCategory = from Category in dbContext.Categories select Category;
            return PartialView(listCategory);
        }
        
    }
}