using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FlightBookingApp
{
    class BALFlight
    {
        //  DALFlight obj = new DALFlight();
        public static DataTable GetFlightDetails()
        {
            return DALFlight.GetFlightDetails();
        }

        public static int AddBooking(int pid, string pname, DateTime Jdate, int Noft, int fid)
        {
            return DALFlight.AddBooking(pid, pname, Jdate, Noft, fid);
        }
    }
}
