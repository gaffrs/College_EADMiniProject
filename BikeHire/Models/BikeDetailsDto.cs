﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeHire.Models
{
    public class BikeDetailsDto                     //DTO(Data transfer Objects) class to get all data
    {
        public String Make { get; set; }
        public String Model { get; set; }
        public double RentalChargePerDay { get; set; }
        public bool BikeAvailable { get; set; }
        public List<Hire> Hires { get; set; }


    }
}