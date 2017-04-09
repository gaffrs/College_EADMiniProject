using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeHire.Models
{
    public class HireDetailsDto
    {
        public int HireID { get; set; }                 
        public int BikeID { get; set; }                     //FK
        public String FirstName { get; set; }
        public String Surname { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public BikeDetailsDto Bikes { get; set; }


        //NEW
        public double RentalDays        //Read ONLY property    
        {
            get
            {
                return ((FinishDate - StartDate).TotalDays);
            }
        }
/*
        public double RentalCost
        {
            get
            {
                return (RentalDays * Bikes.RentalChargePerDay);
            }
        }
        */
    }
}
