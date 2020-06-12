using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}