using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class LibrariyanHome : MaterialForm
    {
        MaterialSkinManager.Themes thememode = MaterialSkinManager.Themes.LIGHT;
        
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public LibrariyanHome()
        {
            InitializeComponent();
           
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = thememode;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            cmbFilterAvalibility.SelectedIndex = 0;
            swtSwitchTheme.Text = "Dark Mode";
        }
        
       
        private void LibrariyanHome_Load(object sender, EventArgs e)
        {
       
            
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void materialFloatingActionButton8_Click(object sender, EventArgs e)
        {

        }

        private void swtSwitchTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (swtSwitchTheme.Checked) {
                swtSwitchTheme.Text = "Light Mode";
                thememode = MaterialSkinManager.Themes.DARK;
                
            }
            else
            {
                swtSwitchTheme.Text = "Dark Mode";
                thememode = MaterialSkinManager.Themes.LIGHT;
            }
            materialSkinManager.Theme = thememode;

        }

        private void LibAddBook_Click(object sender, EventArgs e)
        {
            //LibBookPanel.Controls.Add(new BookTile());
            
            ListViewItem item = new ListViewItem();
            item.SubItems.Add("B01");
            item.SubItems.Add("Sherlock");
            item.SubItems.Add("Mystery");
            item.SubItems.Add("Athur Conan Doyle");
            item.SubItems.Add("Athur Conan Doyle");
            item.SubItems.Add("Unavailable");
            item.SubItems.Add("2021-04-05");
            item.SubItems.Add("2021-04-05");
            item.SubItems.Add("");
            LibBookList.Items.Add(item);

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
