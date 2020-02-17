using HousesForRent.Helpers;
using HousesForRent.Models;
using HousesForRent.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
            var v = context.LeasersInformations.Include(z => z.Location).Where(x => x.UserId == UserId).ToList();
            return v.ToViewModel<LeasersInformation, LeasersInformationViewModel>().ToList();
            
        }

        public List<LocationViewModel> GetAllLocations()
        {
            return context.Locations.ToList().ToViewModel<Location, LocationViewModel>().ToList();
        }

        private Location GetLocation(int id)
        {
            return context.Locations.Where(x => x.Id == id).FirstOrDefault();
        }

        public LocationViewModel GetLocationById(int id)
        {
            return context.Locations.Where(x => x.Id == id).FirstOrDefault()
                .ToViewModelSingle<Location, LocationViewModel>();
        }

        public void AddHouse(LeasersInformation info)
        {
            context.LeasersInformations.Attach(info);
            context.LeasersInformations.Add(info);
            context.SaveChanges();
        }

        

    }
}