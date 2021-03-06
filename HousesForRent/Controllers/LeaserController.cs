﻿using HousesForRent.DataBase;
using HousesForRent.Helpers;
using HousesForRent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousesForRent.Controllers
{
    [Authorize]
    public class LeaserController : Controller
    {
        // PAGES
        public ActionResult AddHouse()
        {
            return View();
        }

        public ActionResult UsersListings()
        {
            if (TempData["PictureLimit"] != null)
            {
                ViewBag.PictureMessage = (string)TempData["PictureLimit"];
            }

            return View(GetUsersListings());
        }

        [HttpPost]
        public ActionResult AddRental(LeasersInformationViewModel infoVM)
        {
            var repo = new LeaserRepository();
            infoVM.UserId = repo.GetUserId(User.Identity.Name);
            infoVM.Location = new Location {Id = infoVM.LocationId };
            infoVM.Expiration =  DateTime.Today.AddMonths(3);
            var info = infoVM.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.AddHouse(info);
            TempData["Recipient"] = "add";
            return RedirectToAction("EmailRecipient", "Home");
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
            if(listing.ContactInfo == null)
            {
                return;
            }
            var info = listing.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.Update(info);
            repo.SaveChanges();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase imageFile, int Id)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            imageFile.SaveAs($"{Server.MapPath("/UploadedImages/")}{fileName}");

            var repo = new LeaserRepository();

            var picLimit = repo.AmountOfPicturesById(Id);
            if (picLimit >= 10)
            {
                TempData["PictureLimit"] = "Limited to 10 pictures only";
                return RedirectToAction("UsersListings");
            }

            repo.UploadImage(fileName, Id);
            return RedirectToAction("UsersListings");
        }

        public ActionResult GetPictures(int PicId)
        {
            var repo = new LeaserRepository();
            return Json(repo.GetPicturesById(PicId), JsonRequestBehavior.AllowGet);
        }

        public void DeletePic(int PicId, string Picture)
        {
            var repo = new LeaserRepository();
            repo.DeletePicturesById(PicId);
            System.IO.File.Delete($"{Server.MapPath("/UploadedImages/")}{Picture}");
        }

        [HttpPost]
        public void Pause(int Id)
        {
            var repo = new LeaserRepository();
            var user = repo.GetUserId(User.Identity.Name);
            repo.PauseListing(Id, user);
        }

        [HttpPost]
        public ActionResult RenewAd(LeasersInformationViewModel listing)
        {
            var repo = new LeaserRepository();
            listing.UserId = repo.GetUserId(User.Identity.Name);
            listing.Location = new Location { Id = listing.LocationId };
            var info = listing.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.RenewAdById(info);
            TempData["Recipient"] = "renew";
            return RedirectToAction("EmailRecipient", "Home");
        }

        [HttpPost]
        public void DeleteItem(int listingId, string UserId)
        {
            var repo = new LeaserRepository();
            var user = repo.GetUserId(User.Identity.Name);
            if(user != UserId)
            {
                return;
            }
            repo.DeleteListing(listingId);
        }
    }
}