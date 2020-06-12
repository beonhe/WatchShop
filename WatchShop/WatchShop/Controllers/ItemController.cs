using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}