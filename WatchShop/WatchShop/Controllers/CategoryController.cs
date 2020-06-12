using System;
using System.Collections.Generic;
using System.Linq;
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
            return View("ThongBao");
        }
    }
}