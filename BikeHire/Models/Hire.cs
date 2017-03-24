using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	

namespace BikeHire.Models
{
    public class Hire
    {
        public int HireID { get; set; }
        [Required]                                          //Not null or empty string
        public int BikeID { get; set; }                     //FK
        [Required]
        public String FirstName { get; set; }
        [Required]                                         
        public String Surname { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Hire start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Hire finish date")]
        public DateTime FinishDate { get; set; }

        //Navigation Property
        public Bike Bike { get; set; }
        //public virtual Bike Bike { get; set; }        //using "virtual" causes and Circular References errors, used DTO


        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */

    }
}