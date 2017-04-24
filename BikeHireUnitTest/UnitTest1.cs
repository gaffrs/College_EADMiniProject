// Create Unit Tests:                    Add New Project - Test - Unit Test Project
// Need to add a reference to link it:   Right click the UnitTest File - Add - Reference - Project - Select the Project
// How to run the Unit Tests:            Test - Run - All Tests
// Check for Code Coverage:              Test - Analyze Code Coverage for all tests
// Debug                                 Test - Debug - All tests

// Assert Class https://msdn.microsoft.com/en-us/library/ms182530.aspx 
// Assert
// Collection Assert
// String Assert


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BikeHire.Models; //required to access the models
using System.ComponentModel.DataAnnotations; //required in order to use ValidationException

namespace BikeHireUnitTest
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void HireRentalDaysTest()
        {
            // arrange  
            Hire b = new Hire();
            // act 
            b.StartDate = new DateTime(2017, 03, 01);
            b.FinishDate = new DateTime(2017, 03, 11);
            // assert
            Assert.AreEqual(b.RentalDays, 10);
        }

        [TestMethod]
        public void HireFieldsTest()
        {
            // arrange           
            Hire b = new Hire();
            // act 
            b.HireID = 1;
            b.FirstName = "firstname";
            b.Surname = "surname";
            b.Address = "dublin";
            b.PhoneNumber = "122222";
            b.StartDate = new DateTime(2017, 03, 01);
            b.FinishDate = new DateTime(2017, 03, 11);
            // assert
            Assert.AreEqual(b.HireID, (1));
            Assert.AreEqual(b.FirstName, ("firstname"));
            Assert.AreEqual(b.Surname, ("surname"));
            Assert.AreEqual(b.Address, ("dublin"));
            Assert.AreEqual(b.PhoneNumber, ("122222"));
            Assert.AreEqual(b.StartDate, (new DateTime(2017, 03, 01)));
            Assert.AreEqual(b.FinishDate, (new DateTime(2017, 03, 11)));
        }

        [TestMethod]
        public void BikeFieldsTest()
        {
            // arrange           
            Bike b = new Bike();
            // act 
            b.BikeID = 1;
            b.Make = "name";
            b.Model = "surname";
            b.RentalChargePerDay = 25;
            b.BikeAvailable = false;
            // assert
            Assert.AreEqual(b.BikeID, (1));
            Assert.AreEqual(b.Make, ("name"));
            Assert.AreEqual(b.Model, ("surname"));
            Assert.AreEqual(b.RentalChargePerDay, (25));
            Assert.AreEqual(b.BikeAvailable, (false));

        }
    }
}
