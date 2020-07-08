using System;
using System.Reflection;
using System.Linq;
using NUnit.Framework;

namespace FlightBookingApp.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        System.Random r = new System.Random();
        private MethodInfo tM1, tM2, tM3;
        private object SUT;
        Assembly assembly;

        [SetUp]
        public void Initialize()
        {
            assembly = Assembly.Load("FlightBookingApp");
            SUT = assembly.CreateInstance(assembly.GetTypes().Where(type => type.Name == "DALFlight").FirstOrDefault()?.FullName,
                false, BindingFlags.CreateInstance, null, null, null, null);
            tM1 = SUT.GetType().GetMethod("GetFlightDetails()");
            tM2 = SUT.GetType().GetMethod("ValidateAvailability()");
            tM3 = SUT.GetType().GetMethod("AddBooking()");


        }
        [Test]
        public void Check_GetFlightDetails_Method_Is_Present()
        {
            Assert.IsNull(tM1, "GetFlightDetails not found");
            if (assembly.GetType("DALFlight") != null)
            {

                Assert.IsNull(tM1, "Method GetFlightDetails NOT implemented OR check spelling");

            }
        }
        [Test]
        public void Check_ValidateAvailability_Method_Is_Present()
        {
            Assert.IsNull(tM2, "ValidateAvailability not found");
            if (assembly.GetType("DALFlight") != null)
            {

                Assert.IsNull(tM2, "Method ValidateAvailability NOT implemented OR check spelling");

            }
        }
        [Test]
        public void Check_AddBooking_Method_Is_Present()
        {
            Assert.IsNull(tM3, "AddBooking not found");
            if (assembly.GetType("DALFlight") != null)
            {

                Assert.IsNull(tM3, "Method AddBooking NOT implemented OR check spelling");

            }
        }

        [Test]
        public void AddBookingTestFail()
        {
            
            try
            {
              int x=  DALFlight.AddBooking(r.Next(),"Ram",DateTime.Now.AddDays(20),80,1);
               int expected = 0;

                //// Act
               int actual = x;

               //// Assert
                Assert.AreEqual(expected, actual, "Success");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void AddBookingTestPass()
        {
            try
            {
                int x = DALFlight.AddBooking(r.Next(), "Ram", DateTime.Now.AddDays(20), 3, 1);
                int expected = 1;

                //// Act
                int actual = x;

                //// Assert
                Assert.AreEqual(expected, actual, "Success");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void CheckValidateAvailabilityTestFail()
        {
            try
            {
                // Arrange

                int FlightID = 1;
                int noft = 100;
                bool expected = false;

                //// Act
                bool availability = DALFlight.ValidateAvailability(FlightID,noft);

                //// Assert
                bool actual = availability;
                Assert.AreEqual(expected, actual, "Success");
            }
            catch (Exception)
            {
                Assert.Fail("Sorry The seats are not available!!");
            }
        }
        [Test]
        public void CheckValidateAvailabilityTestPass()
        {
            try
            {
                // Arrange

                int FlightID = 1;
                int noft = 2;
                bool expected = true;

                //// Act
                bool availability = DALFlight.ValidateAvailability(FlightID, noft);

                //// Assert
                bool actual = availability;
                Assert.AreEqual(expected, actual, "Success");
            }
            catch (Exception)
            {
                Assert.Fail("Sorry The seats are not available!!");
            }
        }
    }

}









