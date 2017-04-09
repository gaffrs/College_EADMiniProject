using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BikeHire.Models; //required to access the models

namespace BikeHireUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HireDetailsDto b = new HireDetailsDto();
            b.StartDate = new DateTime(2017, 03, 01);
            b.FinishDate = new DateTime(2017, 03, 11);

            Assert.AreEqual(b.RentalDays, 11);

        }
    }
}
