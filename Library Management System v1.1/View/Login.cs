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
        Constant.IconClass icons = new Constant.IconClass();
        Controller.LoginController loginController = new Controller.LoginController();
       
        [Obsolete]
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
            metroPanel1.Controls.Clear();
            metroPanel1.Controls.Add(f);
            metroPanel1.Tag = f;
            f.Show();
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            txtemail.Hide();
            txtpass.Hide();
            //lblforgotpass.Hide();
            btnlogin.Hide();
            hideShowPass.Hide();
            Loadform(new QRlogin());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginController.onLoggedIn(new View.LibrariyanDashboard() , "Librariyan");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hideShowPass_Click(object sender, EventArgs e)
        {
            if (hideShowPass.Image == Image.FromFile(icons.showPass))
            {
                txtpass.UseSystemPasswordChar = false;
                hideShowPass.Image = Image.FromFile(icons.hidePass);
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
                hideShowPass.Image = Image.FromFile(icons.showPass);
            }
        }
    }
}
