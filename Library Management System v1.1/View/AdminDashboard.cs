﻿

using LiveCharts.Wpf;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using MetroFramework.Controls;

namespace Library_Management_System_v1._1.View
{
    public partial class AdminDashboard : MaterialForm
    {

        Controller.AdminDashboardController adminDashboardCtrl = new Controller.AdminDashboardController();
        Model.DatabaseService database = new Model.DatabaseService();
        String emp_id;
        public AdminDashboard(String emp_id)
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            this.emp_id = emp_id;
            loadLibrariyanList();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            adminDashboardCtrl.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            timer1.Start();
            adminName.Text = adminDashboardCtrl.setName(emp_id);
            lblNumberOfLibrariyans.Text = librariyanList.Items.Count.ToString();
            lbl_welcomeTxt.Text = "Hello "+ adminDashboardCtrl.setName(emp_id).Split(' ')[0] + ", How're you today?";
            lbl_libraryUpdated.Text = adminDashboardCtrl.setUpdatedTime();
            lbl_notification_count.Text = adminDashboardCtrl.setNotificationCount();
            cmb_filterLibrarians.SelectedIndex = 0;
        }

        


        public void loadLibrariyanList()
        {
            librariyanList.Items.Clear();
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select * From Librarian");
                if (sdr.HasRows) {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["Librarian_Id"].ToString());
                        item.SubItems.Add(sdr["Name"].ToString());
                        item.SubItems.Add(sdr["Address"].ToString());
                        item.SubItems.Add(sdr["Phone"].ToString());
                        item.SubItems.Add(sdr["NIC"].ToString());
                        item.SubItems.Add(sdr["updated_date"].ToString());
                        
                        librariyanList.Items.Add(item);
                    }
                    database.Con.Close();
                    lblNumberOfLibrariyans.Text = librariyanList.Items.Count.ToString();

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                }
                
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (librariyanList != null)
            {
                librariyanList.MultiSelect = false;
            }

        }

        private void adminNotifications_Click(object sender, EventArgs e)
        {
            new AdminNotifications().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            todayDateAdmin.Text = DateTime.Now.ToString();
        }

        private void switchtoLibrariyanBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LibrariyanHome(emp_id).Show();
        }

        [Obsolete]
        private void adminLogout_Click(object sender, EventArgs e)
        {
            int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_id + "'");
            if (line > 0)
            {
                Login lg = new Login();
                lg.Closed += (s, args) => this.Close();
                lg.Show();

            }
            else
            {
                MessageBox.Show("Logout Failed");
            }



        }

        private void addLibrarianBtn_Click(object sender, EventArgs e)
        {
            AddLibrariyan  addLib  = new AddLibrariyan();
            addLib.Show();   
        }

        //=======================Delete Librarian===================================

        private void deleteLibrariyanBtn_Click(object sender, EventArgs e)
        {
 
            DialogResult res = MessageBox.Show("Are you sure ?", "", MessageBoxButtons.YesNo);
            if (res.Equals(DialogResult.Yes)){
                ListView.SelectedIndexCollection selectedIndex = librariyanList.SelectedIndices;
                if (selectedIndex.Count > 0)
                {
                    foreach (int index in selectedIndex)
                    {
                        Console.WriteLine(index);

                    }
                    String selectedRowId = librariyanList.SelectedItems[0].SubItems[0].Text;

                    try
                    {
                        int line = database.deleteData("DELETE FROM Librarian WHERE Librarian_Id = '" + selectedRowId + "'");
                        int line1 = database.deleteData("DELETE FROM AppUser WHERE Emp_Id = '" + selectedRowId + "'");

                        if (line > 0 && line1 > 0)
                        {
                            MessageBox.Show("Data Deleted Successfully");
                            loadLibrariyanList();
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong");
                        }

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("No Rows Selected");

                }
            }
            else{
                MessageBox.Show("Deletation Cancelled");
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            loadLibrariyanList();
        }

        //==========================filter Librarian Search
        private void cmb_filterLibrarians_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroDateTime dateTimeBox = new MetroDateTime();
            MaterialTextBox mTxtBox = new MaterialTextBox();

            if(cmb_filterLibrarians.SelectedIndex == 2)
            {
                searchPanel.Controls.Clear();
                searchPanel.Controls.Add(dateTimeBox);
                dateTimeBox.Dock = DockStyle.Fill;
            }
            else
            {
                searchPanel.Controls.Clear();
                searchPanel.Controls.Add(mTxtBox);
                mTxtBox.Dock = DockStyle.Fill;
                mTxtBox.UseTallSize = false;
            }
            
        }

        private void updateLibrariyanBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String selectedRowId = librariyanList.SelectedItems[0].SubItems[0].Text;
                new AddLibrariyan(true, selectedRowId).Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
