using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HousesForRent.Models
{
    public class LeasersInformation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ContactInfo { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public decimal Bathrooms { get; set; }
        public decimal? Price { get; set; }
        public string Comments { get; set; }
        public DateTime? Date { get; set; }
        public bool Furnished { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }

    public class LeasersInformationViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Bedrooms { get; set; }
        public decimal Bathrooms { get; set; }
        public decimal? Price { get; set; }
        public string ContactInfo { get; set; }
        public string Comments { get; set; }
        public DateTime? Date { get; set; }
        public bool Furnished { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}