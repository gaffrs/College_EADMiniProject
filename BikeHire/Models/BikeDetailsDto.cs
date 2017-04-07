using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;    //enables the [Key], [Required] etc
using System.Data.Entity;                       //enables "DbContext"	


namespace BikeHire.Models
{
    public class BikeDetailsDto                     //DTO(Data transfer Objects) class to get all data
    {
        public int BikeID { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public double RentalChargePerDay { get; set; }
        public bool BikeAvailable { get; set; }
        public List<HireDetailsDto> Hires { get; set; }     //CG 07/04 Hire
    }
}