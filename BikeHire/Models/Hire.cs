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
        [Required(ErrorMessage = "Required field")]         //Not null or empty string
        public int BikeID { get; set; }                     //FK
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Required field")]         //Not null or empty string
        public String Surname { get; set; }
        [Required(ErrorMessage = "Required field")]         //Not null or empty string
        public String Address { get; set; }
        [Required(ErrorMessage = "Required field")]         //Not null or empty string
        public String PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        //Navigation Property
        public Bike Bike { get; set; }
        
        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */

    }
}