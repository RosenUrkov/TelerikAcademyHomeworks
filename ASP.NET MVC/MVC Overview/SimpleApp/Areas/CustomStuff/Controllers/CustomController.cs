using SimpleApp.Areas.CustomStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleApp.Areas.CustomStuff.Controllers
{
    public class CustomController : Controller
    {
        public ActionResult Index(string imageUrl)
        {
            if (imageUrl == null)
            {
                imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8bmLo7vnXhNfPZaSWKRC8TgnniIb3zflgrDIN9aqx-Yed-PK4MQ";
            }

            var model = new CustomModel() { ImageUrl = imageUrl };
            return View(model);
        }
    }
}