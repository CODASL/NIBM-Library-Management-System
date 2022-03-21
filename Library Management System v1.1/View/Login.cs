using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Library_Management_System_v1._1
{
    
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        
        public Login()
        {
            InitializeComponent();
            
          
        }
        public void Loadform(object Form)
        {
            if (this.metroPanel1.Controls.Count > 0)
                this.metroPanel1.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = Dock;
            metroPanel1.Controls.Add(f);
            metroPanel1.Tag = f;
            f.Show();
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            txtemail.Hide();
            txtpass.Hide();
            lblforgotpass.Hide();
            btnlogin.Hide();
            checkBox1.Hide();
            Loadform(new QRlogin());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var libDash = new View.LibrariyanDashboard();
            libDash.Show();

        }
    }
}
