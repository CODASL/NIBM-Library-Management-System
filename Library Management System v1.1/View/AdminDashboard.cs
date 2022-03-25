
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

namespace Library_Management_System_v1._1.View
{
    public partial class AdminDashboard :MaterialForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            
            todayDateAdmin.Text = DateTime.Now.ToString();



        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void materialListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
