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
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Forms;


namespace Library_Management_System_v1._1
{
    
    public partial class Login : MetroForm
    {
        Constant.IconClass icons = new Constant.IconClass();
        Controller.LoginController loginController = new Controller.LoginController();
        Model.DatabaseService database = new Model.DatabaseService();
       

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


        private void resetBtn_Click(object sender, EventArgs e)
        {
            new View.ResetPassword().ShowDialog();
        }




        //====================Login Button Event=======================================================
        [Obsolete]
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtmail.Text == "") 
            {
                MessageBox.Show("Please Enter Employee Id");
            }else if(txtPass.Text == "")
            {
                MessageBox.Show("Please Enter Password");
            }
            else {
                try
                {
                    database.Con.Open();
                    LoginProgress.Increment(10);
                    SqlDataReader sdr = database.readData("Select * From AppUser where Emp_Id = '" + txtmail.Text + "'");
                    LoginProgress.Increment(30);
                    sdr.Read();
                    LoginProgress.Increment(20);
                    loginController.onLoggedIn(sdr, txtPass.Text, this);
                    LoginProgress.Increment(30);
                    database.Con.Close();
                    LoginProgress.Increment(10);
                    LoginProgress.Equals(0);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    LoginProgress.Equals(0);
                    database.Con.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    LoginProgress.Equals(0);
                    database.Con.Close();
                }

            }
      
            
        }
        //=================Login With QR ======================
        private void btnQR_Click(object sender, EventArgs e)
        {
            txtPass.Hide();
            txtmail.Hide();
            btnlogin.Hide();
            Loadform(new QRlogin());
            
        }


        //===================Password Show hide btn ===================
        private void passwordShowHide_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar)
            {
                passwordShowHide.Image = Image.FromFile(icons.hidePass);
                txtPass.PasswordChar = false;
            }
            else
            {
                passwordShowHide.Image = Image.FromFile(icons.showPass);
                txtPass.PasswordChar = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtmail.Focus();
        }

        private void txtmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPass.Focus();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnlogin.PerformClick();
        }
    }
}
