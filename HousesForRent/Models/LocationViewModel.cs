using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesForRent.Models
{

    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }


    public class LocationViewModel
    {
        public int Id { get; set; }
        public string City { get; set; } 
        public string Country { get; set; }
        public string State { get; set; }
    }

   
}