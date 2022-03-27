

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

namespace Library_Management_System_v1._1.View
{
    public partial class AdminDashboard :MaterialForm
    {

        Controller.AdminDashboardController adminDashboardCtrl = new Controller.AdminDashboardController();
        public AdminDashboard()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);


            adminDashboardCtrl.loadCartChart(memberRegistrationChart);
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);
            

        }

       
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
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
            new LibrariyanHome().Show();
        }
    }
}
