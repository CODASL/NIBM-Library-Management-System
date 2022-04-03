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
                SqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                String name = sdr["Name"].ToString().Split(' ')[0];
                //String name = sdr["Name"].ToString();
                database.Con.Close();
                return name;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return ex.ToString();

            }

        }
        public String l_id(String emp_id)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();              
                String empid = sdr["Librarian_Id"].ToString();
                database.Con.Close();
                return empid;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return ex.ToString();

            }

        }
        public String nic(String emp_id)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                String nic = sdr["NIC"].ToString();
                database.Con.Close();
                return nic;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return ex.ToString();

            }

        }
        public String adress(String emp_id)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                String address = sdr["Address"].ToString();
                database.Con.Close();
                return address;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return ex.ToString();

            }

        }
        public String phn(String emp_id)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                String pn = sdr["Phone"].ToString();
                database.Con.Close();
                return pn;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return ex.ToString();

            }

        }

    }
}
