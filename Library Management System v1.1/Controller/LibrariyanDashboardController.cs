using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class LibrariyanDashboardController
    {
        Model.DatabaseService database = new Model.DatabaseService();

        public String setName(String emp_id)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select Name From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                String name = sdr["Name"].ToString();
                database.Con.Close();
                return name;
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }

        }
    }
}
