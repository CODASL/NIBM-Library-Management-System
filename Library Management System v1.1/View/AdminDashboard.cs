

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
        String emp_id;
        public AdminDashboard(String emp_id)
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            this.emp_id = emp_id;
            this.FormClosing += Form_FormClosing;
        }

        //=============On Load Admin Home =============================

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            adminDashboardCtrl.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            timer1.Start();
            adminName.Text = adminDashboardCtrl.setName(emp_id);
            lblNumberOfLibrariyans.Text = librariyanList.Items.Count.ToString();
            lbl_welcomeTxt.Text = "Hello "+ adminDashboardCtrl.setName(emp_id).Split(' ')[0] + ", How're you today?";
            lbl_AdminActivity_LastUpdate.Text = commonController.setUpdatedTime("Updated_Time", "Activity", "Emp_Id", " WHERE Emp_Id= '"+emp_id+"'");
            lbl_notification_count.Text = adminDashboardCtrl.setNotificationCount();
            cmb_filterLibrarians.SelectedIndex = 0;
            loadLibrariyanList();
            loadLibrarianActivities();//Admin Dashboard only All Librarians Activities
            commonController.loadActivities(listview_MyActivitiesAdmin, emp_id);
            lbl_categoryCount.Text = adminDashboardCtrl.setBookCount().ToString();
        }


        //============ form x or F4 click logout user ================================
        [Obsolete]
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_id + "'");
                if (line > 0)
                {
                    this.Hide();
                    Login lg = new Login();
                    lg.Closed += (s, args) => this.Close();
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
                }
                else
                {
                    MessageBox.Show("Application Cannot Logout ", emp_id);
                }
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
        
        //=============Load Librarian List=====================================
        public void loadLibrariyanList()
        {
            librariyanList.Items.Clear();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select * From Librarian");
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
                    lbl_libraryUpdated.Text = commonController.setUpdatedTime("updated_date", "Librarian", "Librarian_Id", "");

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                    database.Con.Close();
                }
                
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                database.Con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            new LibrariyanHome(emp_id).Show();
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

            }
            else
            {
                MessageBox.Show("Logout Failed");
            }
        }

        //======================= Add Btn Manage Librarians ====================================
        private void addLibrarianBtn_Click(object sender, EventArgs e)
        {
            AddLibrariyan  addLib  = new AddLibrariyan();
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
                            MessageBox.Show("Data Deleted Successfully");
                            loadLibrariyanList();
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
            loadLibrariyanList();
        }

        //==================Update Btn Manage Librarians=================
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

        //==================Search Librarians=================
        private void searchTxtBox_TextChanged_1(object sender, EventArgs e)
        {
            if (cmb_filterLibrarians.SelectedIndex == 0)
            {
                adminDashboardCtrl.searchFunction(librariyanList, 0, searchTxtBox);
            }
            else if (cmb_filterLibrarians.SelectedIndex == 1)
            {
                adminDashboardCtrl.searchFunction(librariyanList, 1, searchTxtBox);
            }
        }

        private void btn_refreshLibrarianList_Click(object sender, EventArgs e)
        {
            loadLibrariyanList();
        }

        private void refreshAdminActivties_Click(object sender, EventArgs e)
        {
            commonController.loadActivities(listview_MyActivitiesAdmin, emp_id);
        }

        private void btn_refreshAdminDashboard_Click(object sender, EventArgs e)
        {
            adminDashboardCtrl.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            loadLibrarianActivities();
            lbl_notification_count.Text = adminDashboardCtrl.setNotificationCount();
        }
    }
}
