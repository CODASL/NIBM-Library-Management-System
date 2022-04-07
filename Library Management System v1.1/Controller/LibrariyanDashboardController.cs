using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class LibrariyanDashboardController
    {
        Model.DatabaseService database = new Model.DatabaseService();


        public Model.Librarian setLibrariyan(String emp_id)
        {
            Model.Librarian librarian;
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                if (sdr.HasRows)
                {
                    librarian = new Model.Librarian(
                        emp_id, sdr["Name"].ToString(), sdr["Address"].ToString(), sdr["Email"].ToString(),
                        sdr["NIC"].ToString(), sdr["Phone"].ToString(),Convert.ToDateTime(sdr["updated_date"]),
                        Convert.ToDateTime(sdr["date_added"]));
                }
                else
                {
                    librarian = null;
                }
                database.Con.Close();
                return librarian;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return null;

            }

        }
    }
}
