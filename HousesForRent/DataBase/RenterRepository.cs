using HousesForRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesForRent.DataBase
{
    public class RenterRepository : Repository<LeasersInformation>
    {
        private ApplicationDbContext context = new ApplicationDbContext();

    }
}