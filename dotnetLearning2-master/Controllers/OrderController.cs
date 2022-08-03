using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class OrderController : Controller
    {

        assignmentDbEntities context = new assignmentDbEntities();
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orderList = context.Orders.ToList();
            return View(orderList);
        }

        [HttpGet]
        public ActionResult createOrder() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult createOrder(Order obj)
        {
            context.Orders.Add(obj);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult updateAmount(int id) 
        {
            Order toUpdate = context.Orders.Find(id);

            return View(toUpdate);
        }

        [HttpPost]
        [ActionName("updateAmount")]
        public ActionResult getupdateAmount(Order obj) 
        {
            Order toUpdate = context.Orders.Find(obj.orderId);
            context.Orders.Remove(toUpdate);
            context.Orders.Add(obj);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}