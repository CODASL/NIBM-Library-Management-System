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
    public partial class AdminNotifications : MaterialForm
    {
        Model.DatabaseService database =  new Model.DatabaseService();
        public AdminNotifications()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            loadNotifications();
        }

        
        public void loadNotifications()
        {
            try {

                database.Con.Open();
                SqlDataReader sdr = database.readData("SELECT * FROM Notification");
                while (sdr.Read())
                {
                    notificationTile nTile = new notificationTile(
                            sdr["LID"].ToString(),
                            sdr["Description"].ToString(),
                            sdr["Received_time"].ToString()
                        );
                    notificationList.Controls.Add(nTile);
                    nTile.Click += (sender , e) => notification_Click(sender , e , 1);
                }

                database.Con.Close();

            }
            catch(SqlException ex) {
                MessageBox.Show(ex.ToString());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void notification_Click(object sender, EventArgs e , int id)
        {
            DialogResult dialogResult = MessageBox.Show("Approve Request", "", MessageBoxButtons.YesNoCancel);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Approved");
                database.insertData("UPDATE Notification");
            }
            else if (dialogResult.Equals(DialogResult.No))
            {
                MessageBox.Show("Rejected");
            }
            else
            {
                this.Hide();
            }
        }
    }
}
