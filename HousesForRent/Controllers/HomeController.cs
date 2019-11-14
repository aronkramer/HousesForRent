using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousesForRent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //test is working
            return View();
        }
    }
}