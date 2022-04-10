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
