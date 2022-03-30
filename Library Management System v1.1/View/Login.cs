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
    
    public partial class Login : MaterialForm
    {
        Constant.IconClass icons = new Constant.IconClass();
        Controller.LoginController loginController = new Controller.LoginController();
        Model.DatabaseService database = new Model.DatabaseService();
       
        [Obsolete]
        public Login()
        {
            InitializeComponent();
            //new Controller.MaterialController().addStyle(this);
 
           



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

       

       
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hideShowPass_Click(object sender, EventArgs e)
        {
            //if (hideShowPass.Image == Image.FromFile(icons.showPass))
            //{
            //    //txtpass.UseSystemPasswordChar = false;
            //    hideShowPass.Image = Image.FromFile(icons.hidePass);
            //}
            //else
            //{
            //    //txtpass.UseSystemPasswordChar = true;
            //    hideShowPass.Image = Image.FromFile(icons.showPass);
            //}
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            new View.ResetPassword().ShowDialog();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select * From AppUser where Emp_Id = '" + txtmail.Text + "'");
                sdr.Read();
                loginController.onLoggedIn(sdr, txtPass.Text, this);
                database.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            txtmail.Hide();
            txtPass.Hide();
            //lblforgotpass.Hide();
            btnlogin.Hide();
            //hideShowPass.Hide();
            Loadform(new QRlogin());
        }
    }
}
