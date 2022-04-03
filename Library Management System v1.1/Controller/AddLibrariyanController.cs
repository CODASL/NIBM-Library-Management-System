using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class AddLibrarianController
    {
        public Boolean addLibrarian(Model.Librarian librarian , Model.User appUser)
        {
            Model.DatabaseService database = new Model.DatabaseService();

            int row = database.insertData("INSERT INTO Librarian VALUES('" + librarian.Id + "','" + librarian.Name + "','" + librarian.NIC1 + "'," +
                                "'" + librarian.Address + "','" + librarian.Email + "','" + librarian.UpdatedDate + "','" + librarian.AddedDate + "','" + librarian.Phone + "')");

            int row2 = database.insertData("INSERT INTO AppUser VALUES('" + appUser.EmpID + "','" + appUser.Password + "','" + appUser.EmpType + "','" + 0 + "')");
            return  row > 0 && row2>0;
        }


        public void setLibId(MaterialTextBox textBox)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            String id;
            try
            {
                database.Con.Open();
                SqlDataReader sdr =  database.readData("SELECT TOP 1 Librarian_Id FROM Librarian ORDER BY Librarian_Id DESC");
                sdr.Read();
                id = sdr["Librarian_Id"].ToString();
                database.Con.Close();

                id = "L" + (Convert.ToInt32(id.Remove(0, 1))+1).ToString();
                textBox.Text = id;
            }
            catch (SqlException ex)
            {
                database.Con.Close();

            }
            catch(Exception ex)
            {
                database.Con.Close();
            }
        }


    }
}
