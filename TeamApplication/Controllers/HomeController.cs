using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using TeamApplication.ViewModels;
using TeamApplication.Mapper;
using System.Globalization;

namespace TeamApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var users = new DataLayer.User().GetUsers().Map();

            var membershipTypes = new DataLayer.MembershipType().GetMembershipTypes().ToList();

            ViewBag.MembershipTypes = membershipTypes;

            return View(users);
        }

        public ActionResult AddUser()
        {
            var membershipTypes = new DataLayer.MembershipType().GetMembershipTypes().ToList();

            var viewModel = new UserViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        public ActionResult Language()
        {
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var user = new DataLayer.User().GetUser(Id);

            var membershipTypes = new DataLayer.MembershipType().GetMembershipTypes().ToList();

            var viewModel = new UserViewModel()
            {
                User = user,
                MembershipTypes = membershipTypes
            };

            return View("AddUser", viewModel);
        }

        public ActionResult Save(UserViewModel viewModel)
        {
            if(viewModel.User.Id == 0)
            {
                new DataLayer.User().AddUser(viewModel.User);
                return RedirectToAction("Index");
            }

            var user = new DataLayer.User().GetUser(viewModel.User.Id);

            new DataLayer.User().UpdateUser(viewModel.User);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            new DataLayer.User().DeleteUser(Id);
            
            return RedirectToAction("Index");
        }

        public ActionResult Change(string LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }
    }
}