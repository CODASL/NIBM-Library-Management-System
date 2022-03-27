using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1
{
    public partial class Splash : MetroFramework.Forms.MetroForm
    {
       
        private int borderSize = 2;

        [Obsolete]
        public Splash()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        [Obsolete]
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;
            if (progressBar1.Value > 50)
            {
                this.Hide();
                
                var frm = new Login();
                var frm1 = new View.LibrariyanHome();
                var frm2 = new View.AdminDashboard();

                if (Controller.SplashController.isLoggedIn) { 
                    if(Controller.SplashController.currentUser == "Admin")
                    {
                        timer1.Enabled = false;
                        frm2.Closed += (s, args) => this.Close();
                        frm2.ShowDialog();
                    }
                    else
                    {
                        timer1.Enabled = false;
                        frm1.Closed += (s, args) => this.Close();
                        frm1.ShowDialog();
                    }
                }
                else {
                    timer1.Enabled = false;
                    frm.Closed += (s, args) => this.Close();
                    frm.ShowDialog();
                }
               
            }
        }
    }
}
