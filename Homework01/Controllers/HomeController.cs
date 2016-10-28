using Homework01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework01.Controllers
{
    public class HomeController : Controller
    {
        private CustomersMetadataEntities db = new CustomersMetadataEntities();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult CustomerOverView()
        {
            var customerOverView = db.vw_CustomerOverView;
            return View(customerOverView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}