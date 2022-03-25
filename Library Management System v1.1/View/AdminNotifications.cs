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
    public partial class AdminNotifications : MaterialForm
    {
        public AdminNotifications()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
        }

        private void notification_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void notification_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Approve Request", "", MessageBoxButtons.YesNoCancel);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Approved");
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
