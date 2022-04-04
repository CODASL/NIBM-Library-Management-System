using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_Management_System_v1._1.Model
{
    

    class DatabaseService
    {
        SqlCommand cmd;
        SqlConnection con;

        public SqlConnection Con { get => con; set => con = value; }

        public DatabaseService()
        {
            con = new SqlConnection("Server=tcp:coda-lms.database.windows.net,1433;Initial Catalog=NIBM LMS;Persist Security Info=False;User ID=coda;Password=Mot413654;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public int insertData(String query) {
            con.Open();
            cmd = new SqlCommand(query , con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }


        public int updateData(String query)
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }


        public int deleteData(String query)
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public SqlDataReader readData(String query)
        {
            cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            return sdr;
        }

       
    }
   
}
