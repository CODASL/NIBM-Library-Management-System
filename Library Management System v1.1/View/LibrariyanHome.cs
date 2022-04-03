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
using System.Data.SqlClient;

namespace Library_Management_System_v1._1.View
{
    public partial class LibrariyanHome : MaterialForm
    {

        Controller.MaterialController material = new Controller.MaterialController();
        Controller.LibrariyanDashboardController librariyandash = new Controller.LibrariyanDashboardController();
        Model.DatabaseService DB = new Model.DatabaseService();
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
            timer1.Start();
            lbl_librariyan_name.Text = librariyandash.setName(emp_Id);
            lbl_welcome_note.Text = "Hello "+librariyandash.setName(emp_Id)+ ", How are you today?";
            lbl_member_count.Text = member_count().ToString();
            lbl_book_count_ds.Text = book_count().ToString();
            lbl_tot_books.Text = book_count().ToString();
            lbl_member_name.Text = librariyandash.setName(emp_Id);
            lbl_empid.Text = librariyandash.l_id(emp_Id);
            lbl_nic.Text = librariyandash.nic(emp_Id);
            lbl_phone.Text = librariyandash.phn(emp_Id);
            lbl_address.Text = librariyandash.adress(emp_Id);
            loadMembers();
        }

        public int member_count()
        {
            DB.Con.Open();
            SqlCommand sdr = new SqlCommand ("SELECT Count (*) FROM Member",DB.Con);
            int name = Convert.ToInt32(sdr.ExecuteScalar());
            DB.Con.Close();
            return name;
        }

        public int book_count()
        {
            DB.Con.Open();
            SqlCommand sdr = new SqlCommand("SELECT Count (*) FROM Book", DB.Con);
            int name = Convert.ToInt32(sdr.ExecuteScalar());
            DB.Con.Close();
            return name;
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
                this.Hide();
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

        private void btn_logout_Click(object sender, EventArgs e)
        {
            int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_Id + "'");
            if (line > 0)
            {
                this.Hide();
                var lg = new Login();
                lg.Closed += (s, args) => this.Close();
                lg.Show();

            }
            else
            {
                MessageBox.Show("Logout Failed");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_time_date.Text = "Today  " + DateTime.Now.ToString("yyy-MM-dd ") + DateTime.Now.ToString(" h:mm:ss tt");
        }

        public void loadMembers()
        {
            userListView.Items.Clear();
            try
            {
                DB.Con.Open();
                SqlDataReader sdr = DB.readData("Select * From Member");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["MID"].ToString());
                        item.SubItems.Add(sdr["Name"].ToString());
                        item.SubItems.Add(sdr["Guardian_Id"].ToString());
                        item.SubItems.Add(sdr["Address"].ToString());
                        item.SubItems.Add(sdr["Phone_No"].ToString());
                        item.SubItems.Add(sdr["NIC"].ToString());
                        item.SubItems.Add(sdr["Updated_date"].ToString());

                        userListView.Items.Add(item);
                    }
                    DB.Con.Close();
                    lbl_members_tot.Text = userListView.Items.Count.ToString();

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                    DB.Con.Close();
                }

            }
            catch (SqlException ex)
            {
                DB.Con.Close();
                MessageBox.Show(ex.ToString());
            }

            if (userListView != null)
            {
                userListView.MultiSelect = false;
            }

        }
    }
}
