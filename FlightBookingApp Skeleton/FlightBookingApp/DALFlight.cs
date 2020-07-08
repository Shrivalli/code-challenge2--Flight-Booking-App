using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.ComponentModel.Design;

namespace FlightBookingApp
{
   public class DALFlight //Do not change the class name
    {

        public static DataTable GetFlightDetails() //Do not change the method name
        {
            
            //Retrieve the Flight Details from the database using ADO.NET
            
            
        }

        public static bool ValidateAvailability(int FlightID, int NoOfTickets) //Do not change the method name
        {
            //Check the availability of ticket in the flight by passing the flightId and the
            //Number of Tickets. 
            
        }

        public static int AddBooking(int pid, string pname, DateTime Jdate,int Noft, int fid) //Do not change the method name
        { 
            //Insert the Booking Details which is got from the user into the Database using ADO.NET
            
        }

    }
}
