﻿using HousesForRent.DataBase;
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
        public void AddRental(LeasersInformationViewModel infoVM)
        {
            var repo = new LeaserRepository();
            infoVM.UserId = repo.GetUserId(User.Identity.Name);
            var info = infoVM.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.Add(info);
            repo.SaveChanges();
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

        public ActionResult GetStates(string country)
        {
            var repo = new LeaserRepository();
            return Json(repo.GetAllStates(country), JsonRequestBehavior.AllowGet);
        }
    }
}