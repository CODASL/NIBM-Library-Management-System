

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
using MySql.Data.MySqlClient;
using MetroFramework.Controls;

namespace Library_Management_System_v1._1.View
{
    public partial class AdminDashboard : MaterialForm
    {

        Controller.AdminDashboardController adminDashboardCtrl = new Controller.AdminDashboardController();
        Controller.CommonController commonController = new Controller.CommonController();
        
       
        Model.DatabaseService database = new Model.DatabaseService();
        String emp_id = Controller.LoginController.currentUserId;

        [Obsolete]
        public AdminDashboard()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            this.FormClosing += Form_FormClosing;
        }

        //=============On Load Admin Home =============================

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            Controller.AdminDashboardController.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            timer1.Start();
            adminName.Text = adminDashboardCtrl.setName(emp_id);
            lblNumberOfLibrariyans.Text = librariyanList.Items.Count.ToString();
            lbl_welcomeTxt.Text = "Hello "+ adminDashboardCtrl.setName(emp_id).Split(' ')[0] + ", How're you today?";
            lbl_AdminActivity_LastUpdate.Text = commonController.setUpdatedTime("Updated_Time", "Activity", "Id", " WHERE Emp_id= '"+emp_id+"'");
            lbl_notification_count.Text = adminDashboardCtrl.setNotificationCount();
            cmb_filterLibrarians.SelectedIndex = 0;
            Controller.AdminDashboardController.loadLibrariyanList(librariyanList, lblNumberOfLibrariyans);
            loadLibrarianActivities();
            commonController.loadActivities(listview_MyActivitiesAdmin, emp_id);
            lbl_categoryCount.Text = adminDashboardCtrl.setBookCount().ToString();
            lbl_memberCount.Text = Controller.AdminDashboardController.memberCount.ToString();
            
           
            
        }

        

        //============ form x or F4 click logout user ================================
        [Obsolete]
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_id + "'");
                    if (line > 0)
                    {
                        this.Hide();
                        Login lg = new Login();
                        lg.Closed += (s, args) => this.Close();
                        Controller.CommonController.setActivity("Logout");
                    }
                    else
                    {
                        MessageBox.Show("Application Cannot Logout ", emp_id);
                    }
                }
                if (e.CloseReason == CloseReason.WindowsShutDown)
                {
                    int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_id + "'");
                    if (line > 0)
                    {
                        this.Hide();
                        Login lg = new Login();
                        lg.Closed += (s, args) => this.Close();
                        Controller.CommonController.setActivity("Logout");
                    }
                    else
                    {
                        MessageBox.Show("Application Cannot Logout ", emp_id);
                    }
                }
            
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //================Load Librarian Activities =====================================
        public void loadLibrarianActivities()
        {
            libActivityListAdmin.Items.Clear();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Activity WHERE Emp_type= '"+"Librarian"+"'");
                if (sdr.HasRows)
                {
                     
                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["Emp_id"].ToString());
                        item.SubItems.Add(sdr["Description"].ToString());
                        item.SubItems.Add(sdr["Updated_Time"].ToString());
                        libActivityListAdmin.Items.Add(item);
                    }
                    database.Con.Close();
                }
                else
                {
                    Console.WriteLine("No Data to Show");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
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
        
       

        //=============Admin Notification Btn =============================
        private void adminNotifications_Click(object sender, EventArgs e)
        {
            new AdminNotifications().ShowDialog();
        }

        //============Refresh every second ====================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            todayDateAdmin.Text = DateTime.Now.ToString();
            
        }

        //============Switch to Librarian Btn====================================
        private void switchtoLibrariyanBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LibrariyanHome().Show();
        }

        //===============Admin Logout ========================
        [Obsolete]
        private void adminLogout_Click(object sender, EventArgs e)
        {
            int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_id + "'");
            
            if (line > 0)
            {
                Login lg = new Login();
                this.Hide();
                lg.Closed += (s, args) => this.Close();
                lg.Show();
                Controller.CommonController.setActivity("Logout");
                Controller.LoginController.currentEmpType = null;
                Controller.LoginController.currentUserId = null;

            }
            else
            {
                MessageBox.Show("Logout Failed");
            }
        }

        //======================= Add Btn Manage Librarians ====================================
        private void addLibrarianBtn_Click(object sender, EventArgs e)
        {
            AddLibrariyan  addLib  = new AddLibrariyan(false,null,lbl_libraryUpdated);
            addLib.Show();   
        }


        //======================= Delete Btn Manage Librarians===================================

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
                            Controller.CommonController.setActivity("Deleted Librarian " + selectedRowId + " Data");
                            MessageBox.Show("Data Deleted Successfully");
                            Controller.AdminDashboardController.loadLibrariyanList(librariyanList, lblNumberOfLibrariyans);
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong");
                        }

                    }
                    catch (MySqlException ex)
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

        //=================Refresh Btn Manage Librarians=====================
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            Controller.AdminDashboardController.loadLibrariyanList(librariyanList, lblNumberOfLibrariyans);
        }

        //==================Update Btn Manage Librarians=================
        private void updateLibrariyanBtn_Click(object sender, EventArgs e)
        {
            if (librariyanList.SelectedItems.Count > 0)
            {
                try
                {
                    String selectedRowId = librariyanList.SelectedItems[0].SubItems[0].Text;
                    new AddLibrariyan(true, selectedRowId, lbl_libraryUpdated).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Librarian");
            }
            
            
        }

        //==================Search Librarians================================
        private void searchTxtBox_TextChanged_1(object sender, EventArgs e)
        {
            if(searchTxtBox.Text != "")
            {
                adminDashboardCtrl.searchFunction(librariyanList, cmb_filterLibrarians.SelectedIndex, searchTxtBox);
            }
            else
            {
                Controller.AdminDashboardController.loadLibrariyanList(librariyanList, lblNumberOfLibrariyans);
            }
            
        }

        private void btn_refreshLibrarianList_Click(object sender, EventArgs e)
        {
            Controller.AdminDashboardController.loadLibrariyanList(librariyanList, lblNumberOfLibrariyans);
        }

        private void refreshAdminActivties_Click(object sender, EventArgs e)
        {
            commonController.loadActivities(listview_MyActivitiesAdmin, emp_id);
        }

        private void btn_refreshAdminDashboard_Click(object sender, EventArgs e)
        {
            Controller.AdminDashboardController.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            loadLibrarianActivities();
            lbl_notification_count.Text = adminDashboardCtrl.setNotificationCount();
        }

        private void datePicker_AdminDashboard_ValueChanged(object sender, EventArgs e)
        {
            loadLibrarianActivities();
            for (int i = libActivityListAdmin.Items.Count - 1; i >= 0; i--)
            {
                var item = libActivityListAdmin.Items[i];

                if (Convert.ToDateTime(item.SubItems[2].Text).Date.ToString().ToLower().Contains(datePicker_AdminDashboard.Value.Date.ToString().ToLower()))
                {

                }
                else
                {
                    libActivityListAdmin.Items.Remove(item);
                }
            }
            if (libActivityListAdmin.SelectedItems.Count == 1)
            {
                libActivityListAdmin.Focus();
            }
        }

        private void datePicker_AdminActivities_ValueChanged(object sender, EventArgs e)
        {
            commonController.loadActivities(listview_MyActivitiesAdmin, emp_id);
            for (int i = listview_MyActivitiesAdmin.Items.Count - 1; i >= 0; i--)
            {
                var item = listview_MyActivitiesAdmin.Items[i];

                if (Convert.ToDateTime(item.SubItems[1].Text).Date.ToString().ToLower().Contains(datePicker_AdminActivities.Value.Date.ToString().ToLower()))
                {

                }
                else
                {
                    listview_MyActivitiesAdmin.Items.Remove(item);
                }
            }
            if (listview_MyActivitiesAdmin.SelectedItems.Count == 1)
            {
                listview_MyActivitiesAdmin.Focus();
            }
        }
    }
}
