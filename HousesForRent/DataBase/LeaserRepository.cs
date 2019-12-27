using HousesForRent.Helpers;
using HousesForRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesForRent.DataBase
{
    public class LeaserRepository : Repository<LeasersInformation>
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public string GetUserId(string email)
        {
            return context.Users.FirstOrDefault(e => e.Email == email).Id;
        }
                       
        public List<LeasersInformationViewModel> GetListingsById(string UserId)
        {
            return context.LeasersInformations.Where(x => x.UserId == UserId)
                .ToList().ToViewModel<LeasersInformation, LeasersInformationViewModel>().ToList();
        }

        public List<LocationViewModel> GetAllLocations()
        {
            return context.Locations.ToViewModel<Location, LocationViewModel>().ToList();
        }

    }
}