using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataTable flightdet = BALFlight.GetFlightDetails();
                Console.WriteLine("Please find below the list of Flights Available:");
                foreach (DataRow dr in flightdet.Rows)
                {
                    Console.WriteLine("Flight ID:"+dr.ItemArray[0]);
                    Console.WriteLine("Source:" + dr.ItemArray[1]);
                    Console.WriteLine("Destination:" + dr.ItemArray[2]);
                    Console.WriteLine("Available Tickets:" + dr.ItemArray[3]);
                    Console.WriteLine("Cost Per Ticket:" + dr.ItemArray[4]);
                }

                Console.WriteLine("Enter the Booking Details: ");
                Console.WriteLine("Enter the Passenger ID");
                int pid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Passenger Name");
                string pname = Console.ReadLine();
                Console.WriteLine("Enter the Journey Date");
                DateTime JDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter the Number of Tickets You require:");
                int noft = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Flight ID:");
                int fid = Convert.ToInt32(Console.ReadLine());
                int res = BALFlight.AddBooking(pid, pname, JDate, noft, fid);
                if (res == 1)
                {
                    Console.WriteLine("Successfully Booked the Ticket!!!");
                }
                else
                {
                    Console.WriteLine("Sorry, We do not have those many tickets available in this Flight.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
