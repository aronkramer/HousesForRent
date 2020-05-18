using HousesForRent.Helpers;
using HousesForRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HousesForRent.DataBase
{
    public class RenterRepository : Repository<LeasersInformation>
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public List<LeasersInformationViewModel> GetAllRentals()
        {
            var leasersinfo = context.LeasersInformations.Include(z => z.Location).ToList()
                .Where(x => !x.Paused && x.Expiration > DateTime.Today).ToList();
            return leasersinfo.ToViewModel<LeasersInformation, LeasersInformationViewModel>().ToList();
        }


    }
}