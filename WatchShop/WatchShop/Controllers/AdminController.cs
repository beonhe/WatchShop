using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
    }
}