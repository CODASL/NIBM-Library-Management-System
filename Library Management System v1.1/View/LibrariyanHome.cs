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

        Controller.MaterialController material = new Controller.MaterialController();
        
        public LibrariyanHome()
        {
            InitializeComponent();

            material.addStyle(this);
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
                material.Thememode = MaterialSkinManager.Themes.DARK;
                
            }
            else
            {
                swtSwitchTheme.Text = "Dark Mode";
                material.Thememode = MaterialSkinManager.Themes.LIGHT;
            }
            material.MaterialSkinManager.Theme = material.Thememode;

        }

        private void LibAddBook_Click(object sender, EventArgs e)
        {
            List<Model.Book> Booklist = new List<Model.Book>(){
                new Model.Book("B01", "", "", "", "", "", "", "", new MaterialButton()),
                new Model.Book("B02", "", "", "", "", "", "", "", new MaterialButton()),
                new Model.Book("B03", "", "", "", "", "", "", "", new MaterialButton()),
                new Model.Book("B04", "", "", "", "", "", "", "", new MaterialButton()),

            };
            

            for(int i=0;i<3;i++) {
                ListViewItem item = new ListViewItem("");
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





            


        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void LibrariyanTabController_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialCard12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel24_Click(object sender, EventArgs e)
        {

        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LibBookList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            new View.AddMember().Show();
        }
    }
}
