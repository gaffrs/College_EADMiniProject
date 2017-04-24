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
        [Display(Name = "Bike ID" )]            //Displayed so Shop can see BikeID to give out
        public int BikeID { get; set; }
        [Required(ErrorMessage = "Required field")] //Not null or empty string
        public String Make { get; set; }
        [Required(ErrorMessage = "Required field")]
        public String  Model { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Rental € (per day)")]
        public double RentalChargePerDay { get; set; }
        [Required]
        [Display(Name = "Bike Available")]
        public bool BikeAvailable { get; set; }


        //Navigation Property
        //public List<Hire> hires { get; set; } 
        public virtual List<Hire> hires { get; set; }   //CG: New 04/04/17, using "virtual" causes and Circular References errors, used DTO 

        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */        
    }
}