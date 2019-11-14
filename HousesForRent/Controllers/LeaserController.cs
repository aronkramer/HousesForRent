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
            var info = infoVM.ToViewModelSingle<LeasersInformationViewModel, LeasersInformation>();
            repo.Add(info);
            repo.SaveChanges();
        }


        //test
        //public void Getter(int id)
        //{
        //    var repo = new LeaserRepository();
        //    var x = repo.get(id).ToViewModelSingle<LeasersInformation, LeasersInformationViewModel>();
        //    var qw = repo.get(id);

        //    var allon = repo.getall().ToViewModel<LeasersInformation, LeasersInformationViewModel>();
        //    var allof = repo.getall();

        //}
    }
}