using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Language()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}