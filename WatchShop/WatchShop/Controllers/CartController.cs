using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> lst = AddCart();
           
            ViewBag.TotalQuatity = TotalQuatity();
            ViewBag.TotalPrice = TotalPrice();
            return View(lst);
        }
        private int TotalQuatity()
        {
            int tsl = 0;
            List<Cart> lst = Session["Cart"] as List<Cart>;
            if (lst != null)
            {
                tsl = lst.Sum(n => n.itemQuatity);
            }
            return tsl;
        }
        private long TotalPrice()
        {
            long total = 0;
            List<Cart> lst = Session["Cart"] as List<Cart>;
            if (lst != null)
            {
                total = lst.Sum(n => n.itemPrice);
            }
            return total;
        }
        public List<Cart> AddCart()
        {
            List<Cart> lst = Session["Cart"] as List<Cart>;
            if (lst == null)
            {
                lst = new List<Cart>();
                Session["Cart"] = lst;
            }
            return lst;
        }
        public ActionResult AddToCart(int id, string url)
        {
            List<Cart> lst = AddCart();
            Cart sp = lst.Find(n => n.itemId == id);
            if (sp == null)
            {
                sp = new Cart(id);
                lst.Add(sp);
                return Redirect(url);
            }
            else
            {
                sp.itemQuatity++;
                return Redirect(url);
            }
        }
        public ActionResult Delete(int id)
        {
            List<Cart> lst = AddCart();
            Cart sp = lst.SingleOrDefault(n => n.itemId == id);
            if (sp != null)
            {
                lst.RemoveAll(n => n.itemId == id);
                return RedirectToAction("Index");
            }
            if (lst.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}