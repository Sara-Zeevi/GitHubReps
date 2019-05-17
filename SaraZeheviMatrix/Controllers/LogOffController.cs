using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaraZeheviMatrix.Controllers
{
    public class LogOffController : Controller
    {
        // GET: LogOff
        public ActionResult LogOff()
        {
            Session["CurrentUser"] = null;             
            return RedirectToAction("../Home");        
        }
    }
}