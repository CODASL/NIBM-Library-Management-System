using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        public Boolean updateLibrarian(Model.Librarian librarian) {
            Model.DatabaseService database = new Model.DatabaseService();
            int row = database.updateData("UPDATE Librarian SET Name = '" + librarian.Name + "',NIC = '" + librarian.NIC1 + "', Address = '" + librarian.Address + "', Email = '" + librarian.Email + "' , Phone = '" + librarian.Phone + "' WHERE Librarian_Id = '" + librarian.Id + "'");
            return row > 0;
        }


        public void setLibId(MaterialTextBox textBox)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            String id;
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT TOP 1 Librarian_Id FROM Librarian ORDER BY Librarian_Id DESC");
                sdr.Read();
                if (sdr.HasRows)
                {
                    id = sdr["Librarian_Id"].ToString();
                    database.Con.Close();
                    id = "L" + (Convert.ToInt32(id.Remove(0, 1)) + 1).ToString();
                }
                else
                {
                    database.Con.Close();
                    id = "L1";
                }
                
                
                textBox.Text = id;
            }catch(MySqlException ex)
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
