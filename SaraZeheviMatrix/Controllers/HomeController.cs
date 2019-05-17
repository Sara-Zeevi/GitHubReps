using SaraZeheviMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SaraZeheviMatrix.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// front page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        /// <summary>
        /// Check user details and save in session
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Login(User user)
        {
            if (user.UserName != null && user.Email != null && user.Password != null)
            { Session["CurrentUser"] = user;
                return RedirectToAction("../GitHub/GetProject", user);
            }
            return RedirectToAction("../Home/Index");
        }       

    }
}
