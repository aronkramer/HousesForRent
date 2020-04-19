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
        // PAGES
        public ActionResult AddHouse()
        {
            return View();
        }

        public ActionResult UsersListings()
        {
            var v = GetUsersListings();
            return View(v);
        }

        [HttpPost]
        public ActionResult AddRental(LeasersInformationViewModel infoVM)
        {
            var repo = new LeaserRepository();
            infoVM.UserId = repo.GetUserId(User.Identity.Name);
            infoVM.Location = new Location {Id = infoVM.LocationId };
            var info = infoVM.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.AddHouse(info);
            return Json(new
            {
                newUrl = Url.Action("UsersListings", "Leaser")
            });
        }

        public ActionResult GetUsersListings()
        {
            var repo = new LeaserRepository();
            var Id = repo.GetUserId(User.Identity.Name);
            return Json(repo.GetListingsById(Id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocations()
        {
            var repo = new LeaserRepository();
            return Json(repo.GetAllLocations(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocationById(int Id)
        {
            var repo = new LeaserRepository();
            return Json(repo.GetLocationById(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Update(LeasersInformationViewModel listing)
        {
            var repo = new LeaserRepository();
            listing.UserId = repo.GetUserId(User.Identity.Name);
            listing.Location = new Location { Id = listing.LocationId };
            var hello = listing;
            var info = listing.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.Update(info);
            repo.SaveChanges();
        }
    }
}