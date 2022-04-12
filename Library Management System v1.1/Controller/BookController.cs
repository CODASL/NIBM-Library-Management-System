using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Management_System_v1._1.Controller
{
    class BookController
    {
        //============================Add Book ===========================================================

        public Boolean addBook(Model.Book book)
        {
            Model.DatabaseService database = new Model.DatabaseService();
           
                int row = database.insertData("INSERT INTO Book VALUES('" + book.Id + "','" + book.Name + "','" + book.Category + "','" + book.Author + "'," +
                    "'" + book.Isbn + "','" + book.Availibility + "','" + book.RackNo + "','" + book.AddedDate.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                    + book.UpdatedDate.ToString("yyyy-MM-dd HH:mm:ss") + "')");

            return row > 0;
        }

        //============================Update Book ===========================================================

        public Boolean updateBook(Model.Book book)
        {
            Model.DatabaseService database = new Model.DatabaseService();

            int row = database.updateData("UPDATE Book SET Name = '"+book.Name+"', Category='"+book.Category+"',Author ='"+book.Author+"'," +
                "ISBN ='"+book.Isbn+ "',Availability = '" + book.Availibility+ "',Rack_No='"+book.RackNo+ "',Date_updated = '"+book.UpdatedDate.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE BID = '"+book.Id+"'");

            return row > 0;
        }

        //========================Load  Category , Rack , Author Combo Boxes =============================
        public static void loadComboBoxes(MaterialComboBox cmbBox, String tableName, String columnName)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                cmbBox.Items.Clear();
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select * From " + tableName);
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        cmbBox.Items.Add(sdr[columnName].ToString());
                    }
                }
                else
                {
                    cmbBox.Items.Add("No " + tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
        }
    }
}
