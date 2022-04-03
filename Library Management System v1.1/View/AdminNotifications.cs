﻿using MaterialSkin.Controls;
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
                SqlDataReader sdr = database.readData("SELECT * FROM Notification WHERE Status = '"+""+"'");
                while (sdr.Read())
                {
                    if (sdr.HasRows)
                    {
                        notificationTile nTile = new notificationTile(
                            sdr["LID"].ToString(),
                            sdr["Description"].ToString(),
                            sdr["Recieved_time"].ToString(),
                            Convert.ToInt32(sdr["notification_id"])
                        );
                        notificationList.Controls.Add(nTile);
                    }     
                }

                database.Con.Close();

            }
            catch(SqlException ex) {
                MessageBox.Show(ex.Message);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void notification_Click(object sender, EventArgs e , int id)
        {
            
            
        }

       
    }
}
