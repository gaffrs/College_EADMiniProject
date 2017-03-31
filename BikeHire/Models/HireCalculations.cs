using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

using BikeHire.Models;

namespace BikeHire.Models
{
    public class HireCalculations
    {

        //Navigation Property
        public Bike Bike { get; set; }
        //Navigation Property
        public ICollection<Hire> hires { get; set; }

        //Property to Calculate Rental Cost
        [Display(Name = "Rental Charge € ")]
        public double RentalCharge        //Read ONLY property    
        {
            get
            {
                return 00.00;
                    //RentalDays * Bike.RentalChargePerDay;
            }
        }
        
    }
}