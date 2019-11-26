using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HousesForRent.Models
{
    public class Timer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int Days { get; set; }
    }

    public class TimerViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Days { get; set; }
    }
}