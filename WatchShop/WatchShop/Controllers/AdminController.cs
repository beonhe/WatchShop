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
        
        public ActionResult Brands()
        {
            List<Brand> listBrand = dbContext.Brands.ToList();//database
            return View(listBrand);
        }
        
    }
}