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
   public class DALFlight
    {

            public static SqlConnection sqlConnection = null;
            public static SqlCommand sqlCommand = null;
            public static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            public static DataSet dataset = new DataSet();
            public static DataTable dataTable;
            static readonly string connection = ConfigurationManager.ConnectionStrings["FlightBooking"].ConnectionString;

        public static DataTable GetFlightDetails()
        {
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from FlightDetails", sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataset = new DataSet();
                sqlDataAdapter.Fill(dataset);
                dataTable = dataset.Tables[0];
                return dataTable;
            }
        }

        public static bool ValidateAvailability(int FlightID, int NoOfTickets)
        {
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                bool flag = false;
                sqlCommand = new SqlCommand("select * from FlightDetails where FlightID = @Fid and @noft < AvailableTickets", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Fid", FlightID);
                sqlCommand.Parameters.AddWithValue("@noft", NoOfTickets);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataset = new DataSet();
                sqlDataAdapter.Fill(dataset);
                dataTable = new DataTable();
                dataTable = dataset.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    flag = true;
                }
                return flag;
            }
        }

        public static int AddBooking(int pid, string pname, DateTime Jdate,int Noft, int fid)
        { 
            bool status = ValidateAvailability(fid,Noft);
            int res = 0;
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select CostperTicket from flightdetails where FlightID =@fid")
                {
                    Connection = sqlConnection
                };
                sqlCommand.Parameters.AddWithValue("@fid", fid);
                
                int cost = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (status == true)
                {

                    sqlCommand = new SqlCommand("insert into BookingDetails values (@pid,@pname,@jdate,@noft,@fid,@totalcharge)")
                    {
                        Connection = sqlConnection
                    };
                    sqlCommand.Parameters.AddWithValue("@pid", pid);
                    sqlCommand.Parameters.AddWithValue("@pname", pname);
                    sqlCommand.Parameters.AddWithValue("@jdate", Jdate);
                    sqlCommand.Parameters.AddWithValue("@noft", Noft);
                    sqlCommand.Parameters.AddWithValue("@fid", fid);
                    int totalCharge = cost * Noft;
                    sqlCommand.Parameters.AddWithValue("@totalcharge", totalCharge);
                    res = sqlCommand.ExecuteNonQuery();
                }

                return res;
            }
        }

    }
}
