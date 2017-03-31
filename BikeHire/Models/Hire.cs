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
        [Display(Name = "Hire ID")]
        public int HireID { get; set; }
        [Required]                                          //Not null or empty string
        public int BikeID { get; set; }                     //FK

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Last Name")]
        public String Surname { get; set; }

        [Required(ErrorMessage = "Required field")]
        public String Address { get; set; }

        /*//Other Phone attribute option
		[Required(ErrorMessage = "Number must not be blank")] //Not null or empty string
        // string 10 characters long & no shorter than 10 characters
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
        [Display(Name = "Phone Number")]             
        public String PhoneNumber { get; set; }
		*/

        [Required(ErrorMessage = "Required field")]
        [Phone]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire finish date")]
        public DateTime FinishDate { get; set; }

        //Navigation Property
        public Bike Bike { get; set; }
        //public virtual Bike Bike { get; set; }        //using "virtual" causes and Circular References errors, used DTO


        /*  Here we are considering a One - Many relationship between Bike and Hires (Customers)
            Assumption that; 
                Hire (Customer) has 1 Bike
                Bike has Many Hires (Customers) */

        //Property to Calculate Rental Days
        [Display(Name = "Rental Days ")]
        public double RentalDays        //Read ONLY property    
        {
            get
            {
                return ((FinishDate - StartDate).TotalDays);
            }
        }
        
        //Property to Calculate Rental Cost
        [Display(Name = "Rental Charge € ")]
        public double RentalCharge        //Read ONLY property    
        {
            get
            {
                return RentalDays * Bike.RentalChargePerDay;
            }
        }





        /*
                //Property to Calculate Rental Cost
                [Display(Name = "Rental Cost: € ")]
                public double RentalCost        //Read ONLY property    
                {
                    get
                    {
                        return ((FinishDate - StartDate).TotalDays) * Bike.RentalChargePerDay;
                    }
                }
        */
    }
}