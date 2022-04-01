using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.View
{
    public partial class ResetPassword : MaterialForm
    {

        Model.DatabaseService database = new Model.DatabaseService();
        public ResetPassword()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            loadLibrariyanIds();
            
        }


        public void loadLibrariyanIds()
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("SELECT Librarian_Id FROM Librarian");
                while (sdr.Read())
                {

                    cmb_libID.Items.Add(sdr["Librarian_Id"]);
                }
                database.Con.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public int generateNotificationID()
        {
            String id;
            try {
                database.Con.Open();
                SqlDataReader sdr = database.readData("SELECT TOP 1 notification_id FROM Notification ORDER BY notification_id DESC");
                sdr.Read();
                id = sdr["notification_id"].ToString();
                database.Con.Close();
                return (Convert.ToInt32(id) + 1); 

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return 0;
        }

        private void requestBtn_Click(object sender, EventArgs e)
        {
            if (cmb_libID.SelectedItem == null)
            {
                MessageBox.Show("Please Select you Employee Id");
            }else if(txt_reason.Text == "")
            {
                MessageBox.Show("Please enter reason for Reset");
            }
            else
            {
                try
                {
                    int line = database.insertData("INSERT INTO Notification VALUES ('" + "A01" + "','" + cmb_libID.SelectedItem.ToString() + "','" + txt_reason.Text + "','" + DateTime.Now.ToString() + "','"+""+"','"+generateNotificationID()+"')");
                    if (line > 0)
                    {
                        MessageBox.Show("Request Sent Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong. Try Again Later");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}
