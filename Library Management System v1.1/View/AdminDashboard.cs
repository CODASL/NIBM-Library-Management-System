

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
        }




        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            adminDashboardCtrl.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            timer1.Start();
            adminName.Text = adminDashboardCtrl.setName(emp_id);
            loadLibrariyanList();
        }


        private void loadLibrariyanList()
        {
            librariyanList.MultiSelect = false;
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

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                }
                
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
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
                this.Hide();
                new Login().Show();

            }
            else
            {
                MessageBox.Show("Logout Failed");
            }



        }

        private void addLibrarianBtn_Click(object sender, EventArgs e)
        {
            new AddLibrariyan().Show();

        }

        private void deleteLibrariyanBtn_Click(object sender, EventArgs e)
        {

           
        }
    }
}
