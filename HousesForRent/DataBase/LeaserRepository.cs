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

        public void AddDays(Timer timer)
        {
            context.Timers.Add(timer);
        }
        

    }
}