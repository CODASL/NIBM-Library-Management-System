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
    public partial class Splash : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;
            if (progressBar1.Value > 45)
            {
                this.Hide();
                var frm = new Login();
                timer1.Enabled = false;
                frm.Closed += (s, args) => this.Close();
                frm.ShowDialog();
            }
        }
    }
}
