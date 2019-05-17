using Newtonsoft.Json.Linq;
using SaraZeheviMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SaraZeheviMatrix.Controllers
{
    public class GitHubController : Controller
    {
        // GET: GitHub
        /// <summary>
        /// Search for a desired project
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProject()
        {
            if (Session["CurrentUser"] != null)
                return View(Session["CurrentUser"]);
            return RedirectToAction("../Home");
        }
        /// <summary>
        /// Add a project to a bookmark
        /// </summary>
        /// <param name="bookmarkJson"></param>
        /// <returns></returns>
        public ActionResult AddBookmark([FromBody]string bookmarkJson)
        {
            if (Session["CurrentUser"] != null && !string.IsNullOrEmpty(bookmarkJson))
            {
                if (((User)Session["CurrentUser"]).Bookmarks != null)
                    ((User)Session["CurrentUser"]).Bookmarks.Add(bookmarkJson);
                else
                {
                    ((User)Session["CurrentUser"]).Bookmarks = new List<string> { bookmarkJson };
                }


                return Json(true);
            }
            return Json(false);
        }
        /// <summary>
        /// Remove a project for a bookmark
        /// </summary>
        /// <param name="bookmarkJson"></param>
        /// <returns></returns>
        public ActionResult RemoveBookmark([FromBody]string bookmarkJson)
        {
            if (Session["CurrentUser"] != null)
            {
                ((User)Session["CurrentUser"]).Bookmarks.Remove(bookmarkJson);
                return Json(true);
            }
            return Json(false);
        }
    }
}