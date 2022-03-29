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
        String emp_Id;
        
        public LibrariyanHome(String emp_Id)
        {
            InitializeComponent();

            material.addStyle(this);
            cmbFilterAvalibility.SelectedIndex = 0;
            this.emp_Id = emp_Id;
          
        }
        
       
        private void LibrariyanHome_Load(object sender, EventArgs e)
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

        private void LibaddMemberBtn_Click(object sender, EventArgs e)
        {
            new AddMember().ShowDialog();
        }

        private void addMemberDashboard_Click(object sender, EventArgs e)
        {
            new AddMember().ShowDialog();
        }

        private void addBookDashboardBtn_Click(object sender, EventArgs e)
        {
            new AddBook().ShowDialog();
        }

        private void addBorrowDashBoardBtn_Click(object sender, EventArgs e)
        {
            new Add_Book_Borrowing_Details().ShowDialog();
        }

        private void borrowBookBtn_Click(object sender, EventArgs e)
        {
            new Add_Book_Borrowing_Details().ShowDialog();
        }

        private void LibrariyanDashBoard_Click(object sender, EventArgs e)
        {

        }

        private void returnBookBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult  = MessageBox.Show("Have Any Damages in Book ?","" , MessageBoxButtons.YesNoCancel);
            if (dialogresult.Equals(DialogResult.Yes))
            {
                Console.WriteLine(dialogresult.ToString());
                new AddfineWindow().ShowDialog();
                
            }
            else if(dialogresult.Equals(DialogResult.No))
            {
                Console.WriteLine(dialogresult.ToString());
                DialogResult dialogresult1 = MessageBox.Show("Are you sure that member retured Book?", "", MessageBoxButtons.YesNo);
                if (dialogresult1.Equals(DialogResult.Yes))
                {
                    Console.WriteLine("Database should update Status into returned");
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
           
        }

        private void PayMemberFee_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Are you sure That Member Paid Fee ?", "", MessageBoxButtons.YesNo);
            if (dialogresult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Member Fee Updated");
            }
            else
            {
      
            }
        }

        private void addBookDashBoard_Click(object sender, EventArgs e)
        {
            new AddBook().Show();
        }

        private void addCategoryDashboard_Click(object sender, EventArgs e)
        {
            new Add_Category().Show();
        }

        private void addAuthorDashboard_Click(object sender, EventArgs e)
        {
            new Add_Author().Show();
        }
    }
}
