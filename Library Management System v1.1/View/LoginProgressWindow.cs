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
    public partial class LoginProgressWindow : Form
    {
        Boolean isError;
        public LoginProgressWindow()
        {
            InitializeComponent();
        }

        private void LoginBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Controller.LibrariyanDashboardController.loadMembers();


            }catch(Exception ex)
            {
                LoginBackgroundWorker.CancelAsync();
                MessageBox.Show(ex.Message);
            }
            
        }

        private void LoginBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadProgress.Value += 20;
        }

        [Obsolete]
        private void LoginBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!isError)
            {
                if(Controller.LoginController.currentEmpType == "Admin")
                {
                    new AdminDashboard().ShowDialog();
                }
                else
                {
                    new LibrariyanHome().ShowDialog();
                }
            }
            else
            {
                this.Hide();
                this.Closed += (s, args) => this.Close();
            }

        }

        private void LoginProgressWindow_Load(object sender, EventArgs e)
        {
            LoginBackgroundWorker.RunWorkerAsync();
        }
    }
}
