using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleApp.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id, string value)
        {
            var model = new Default();
            if (value != null)
            {
                model.Value = value;
            }
            else
            {
                model.Value = "1st";
            }

            // both result as 3rd - they are the same thing
            ViewBag.Value = "2nd";
            ViewData["Value"] = "3rd";

            return View("default", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Default formModel)
        {
            if (ModelState.IsValid)
            {
                return this.RedirectToAction("index", new { id = 42, value = formModel.Value });
            }

            return new EmptyResult();
        }
    }
}