using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace BikeHire.Models
{
    public class Bike
    {
        public int BikeID { get; set; }
        [Required]
        public String Make { get; set; }
        [Required]
        public String  Model { get; set; }
        [Required]
        [Display(Name = "Rental charge per day")]
        public double RentalChargePerDay { get; set; }
        [Required]
        [Display(Name = "Bike Available")]
        public bool BikeAvailable { get; set; }


        //Navigation Property
        public ICollection<Hire> hires { get; set; }

        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */
    }
}