using HousesForRent.DataBase;
using HousesForRent.Helpers;
using HousesForRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousesForRent.Controllers
{
    public class TenantController : Controller
    {
        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult AllRentals()
        {
            var repo = new RenterRepository();
            var listOfHouses = repo.GetAll().ToViewModel<LeasersInformation, LeasersInformationViewModel>();
            return Json(listOfHouses, JsonRequestBehavior.AllowGet);
        }
    }
}