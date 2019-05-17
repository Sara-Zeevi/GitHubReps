using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaraZeheviMatrix.Controllers
{
    public class BookmarkCartController : Controller
    {
        // GET: bookmarkCart
        /// <summary>
        ///list bookmark
        /// </summary>
        /// <returns></returns>
        public ActionResult Bookmark()
        {
            if (Session["CurrentUser"] != null)
                return View(Session["CurrentUser"]);
            return RedirectToAction("../Home");

        }
    }
}