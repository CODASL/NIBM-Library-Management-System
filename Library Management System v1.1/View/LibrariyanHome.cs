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
            new View.AddBook().ShowDialog();
        }

        private void materialButton2_Click(object sender, EventArgs e)
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

        private void LibaddMemberBtn_Click(object sender, EventArgs e)
        {
            new View.AddMember().ShowDialog();
        }

        private void addMemberDashboard_Click(object sender, EventArgs e)
        {
            new View.AddMember().ShowDialog();
        }

        private void addBookDashboardBtn_Click(object sender, EventArgs e)
        {
            new View.AddBook().ShowDialog();
        }

        private void addBorrowDashBoardBtn_Click(object sender, EventArgs e)
        {
            new View.Add_Book_Borrowing_Details().ShowDialog();
        }

        private void borrowBookBtn_Click(object sender, EventArgs e)
        {
            new View.Add_Book_Borrowing_Details().ShowDialog();
        }

        private void LibrariyanDashBoard_Click(object sender, EventArgs e)
        {

        }
    }
}
