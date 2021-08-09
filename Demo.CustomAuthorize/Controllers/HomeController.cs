using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Demo.CustomAuthorize.Models;

namespace Demo.CustomAuthorize.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM formData)
        {
            if (FormsAuthentication.Authenticate(formData.Account, formData.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(formData.Account, false);

                return null;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "帳號或密碼有誤");
                return View(formData);
            }
        }

        //限定T1能登入
        [FactoryAuthorize("T1")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //限定T2能登入
        [FactoryAuthorize("T1", "T2")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}