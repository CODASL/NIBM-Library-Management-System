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
    public partial class Splash :MaterialSkin.Controls.MaterialForm
    {
        
        private int borderSize = 2;
        public Splash()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
            progressBar1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
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
                timer1.Enabled = false;
                frm.Closed += (s, args) => this.Close();
                frm.ShowDialog();
            }
        }
    }
}
