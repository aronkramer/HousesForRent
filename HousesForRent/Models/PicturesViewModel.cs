using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesForRent.Models
{

    public class Pictures
    {
        public int Id { get; set; }
        public int FileName { get; set; }
        public string Picture { get; set; }
    }

    public class PicturesViewModel
    {
        public int Id { get; set; }
        public int FileName { get; set; }
        public string Picture { get; set; }
    }
}