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
    public class LeaserController : Controller
    {
        // GET: Leaser
        public ActionResult AddHouse()
        {
            return View();
        }

        [HttpPost]
        public void AddRental(LeasersInformationViewModel infoVM)
        {
            var repo = new LeaserRepository();
            infoVM.UserId = repo.GetUserId(User.Identity.Name);
            var info = infoVM.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.Add(info);
            repo.SaveChanges();
        }

        [HttpPost]
        public void AddTime(int tim)
        {
            var repo = new LeaserRepository();

            var v = new TimerViewModel
            {
                UserId = repo.GetUserId(User.Identity.Name),
                Days = tim,
            }.ToViewModelSingle<TimerViewModel, Timer>();
            repo.AddDays(v);
        }
    }
}