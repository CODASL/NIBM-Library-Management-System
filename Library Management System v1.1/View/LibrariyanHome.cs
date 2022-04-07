using LiveCharts;
using LiveCharts.Wpf;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
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
        Controller.LibrariyanDashboardController librariyandash = new Controller.LibrariyanDashboardController();
        Controller.CommonController commonController = new Controller.CommonController();
        Model.DatabaseService DB = new Model.DatabaseService();
        Model.Librarian librarian;
        String emp_Id;

        [Obsolete]
        public LibrariyanHome(String emp_Id)
        {
            InitializeComponent();

            material.addStyle(this);
            cmbFilterAvalibility.SelectedIndex = 0;
            this.emp_Id = emp_Id;
            timer1.Start();
            this.FormClosing += Form_FormClosing;
        }
        
       //=========================On Load Librarian Home ==========================================
        private void LibrariyanHome_Load(object sender, EventArgs e)
        {
            //librarian = librariyandash.setLibrariyan(emp_Id);
            //lbl_librariyan_name.Text = librarian.Name;
            //lbl_welcome_note.Text = "Hello " + librarian.Name.Split(' ')[0] + ", How're you today?";
            //loadDashboardTileCounts();
            //loadMembers();
            //loadBooks();
            //loadBookIssues();
            //profileDetailUpdate();
            //commonController.loadActivities(listview_librarianActivities, emp_Id);//Method from Common Controller Class
            //lbl_AccountingLastUpdate.Text = commonController.setUpdatedTime("Updated_Date", "Accounting", "Fine_Id", "");
        }

        public void loadDashboardTileCounts()
        {
            lbl_members_count.Text = tile_count("SELECT * FROM Member").ToString();
            lbl_books_count.Text = tile_count("SELECT * FROM Book").ToString();
            lbl_BookIssuedCount.Text = tile_count("SELECT * FROM [dbo].[Book_Issue] WHERE CONVERT(DATE, Updated_date) = '" + dateTimeLibrarian.Value.Date + "' AND Status='" + true + "'").ToString();
            lbl_BooksReturnedCount.Text = tile_count("SELECT * FROM [dbo].[Book_Issue] WHERE CONVERT(DATE, Updated_date) = '" + dateTimeLibrarian.Value.Date + "' AND Status='" + false + "'").ToString();
        }

        //============ form x or F4 click logout user ================================
        [Obsolete]
        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_Id + "'");
                if (line > 0)
                {
                    this.Hide();
                    Login lg = new Login();
                    lg.Closed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Application Cannot Logout ", emp_Id);
                }
            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_Id + "'");
                if (line > 0)
                {
                    this.Hide();
                    Login lg = new Login();
                    lg.Closed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Application Cannot Logout ", emp_Id);
                }
            }

        }
        //=====================Load Members to Member List view =====================================
        public void loadMembers()
        {
            userListView.Items.Clear();
            try
            {
                DB.Con.Open();
                MySqlDataReader sdr = DB.readData("Select * From Member");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["MID"].ToString());
                        item.SubItems.Add(sdr["Guardian_Id"].ToString());
                        item.SubItems.Add(sdr["Name"].ToString());
                        item.SubItems.Add(sdr["Address"].ToString());
                        item.SubItems.Add(sdr["Phone_No"].ToString());
                        item.SubItems.Add(sdr["NIC"].ToString());
                        item.SubItems.Add(sdr["Updated_date"].ToString());

                        userListView.Items.Add(item);
                    }
                    DB.Con.Close();
                    lbl_members_tot.Text = userListView.Items.Count.ToString();
                    lbl_membersLastUpdate.Text = commonController.setUpdatedTime("Updated_Date", "Member", "MID", "");
                }
                else
                {
                    Console.WriteLine("No Data to Show");
                    DB.Con.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                DB.Con.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                DB.Con.Close();
            }
        }

        //=====================Load Books to Book List view =====================================
        public void loadBooks()
        {
            LibBookList.Items.Clear();
            try
            {
                DB.Con.Open();
                MySqlDataReader sdr = DB.readData("Select * From Book");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["ISBN"].ToString());
                        item.SubItems.Add(sdr["Name"].ToString());
                        item.SubItems.Add(sdr["Category"].ToString());
                        item.SubItems.Add(sdr["Author"].ToString());
                        item.SubItems.Add(sdr["Availability"].ToString());
                        item.SubItems.Add(sdr["Rack_No"].ToString());
                        item.SubItems.Add(sdr["Date_Updated"].ToString());

                        LibBookList.Items.Add(item);
                    }
                    DB.Con.Close();
                    lbl_totalBookCount.Text = LibBookList.Items.Count.ToString();
                    lbl_BooksLastUpdate.Text = commonController.setUpdatedTime("Date_Updated", "Book", "BID", "");

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                    DB.Con.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                DB.Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                DB.Con.Close();
            }
        }

        //=====================Load Book_Issues to Book Issue List view =====================================
        public void loadBookIssues()
        {
            listView_issueBooks.Items.Clear();
            try
            {
                DB.Con.Open();
                MySqlDataReader sdr = DB.readData("Select * From Book_Issue");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["BID"].ToString());
                        item.SubItems.Add(sdr["MID"].ToString());
                        item.SubItems.Add(sdr["LID"].ToString());
                        item.SubItems.Add(sdr["issued_dateTime"].ToString());
                        item.SubItems.Add(sdr["Return_date"].ToString());
                        item.SubItems.Add(sdr["Status"].ToString());
                        

                        listView_issueBooks.Items.Add(item);
                    }
                    DB.Con.Close();
                    lbl_totalBookIssueCount.Text = listView_issueBooks.Items.Count.ToString();
                    lbl_IssueBookLastUpdate.Text = commonController.setUpdatedTime("Updated_date", "Book_Issue", "ID", "");

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                    DB.Con.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                DB.Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                DB.Con.Close();
            }
        }

        //=======================set Dashboard tile Counts ========================================
        public int tile_count(String query)
        {
            int count = 0;
            try
            {
                DB.Con.Open();
                MySqlDataReader sdr = DB.readData(query);
              
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        count = count + 1;
                    }
                }
                DB.Con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                DB.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DB.Con.Close();
            }
            return count;
        }

        //===============Switch Dark Theme Light Theme ===========================
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

        //=================Add Book Btn =======================
        private void LibAddBook_Click(object sender, EventArgs e)
        {
            new View.AddBook().ShowDialog();
        }

        //=================Add Members Btn =======================
        private void LibaddMemberBtn_Click(object sender, EventArgs e)
        {
            new AddMember().ShowDialog();
        }

        //=================Add Member Dashboard Btn =======================
        private void addMemberDashboard_Click(object sender, EventArgs e)
        {
            new AddMember().ShowDialog();
        }

        //=================Add Book Dashboard Btn =======================
        private void addBookDashboardBtn_Click(object sender, EventArgs e)
        {
            new AddBook().ShowDialog();
        }

        //=================Add Book Issue Dashboard Btn =======================
        private void addBorrowDashBoardBtn_Click(object sender, EventArgs e)
        {
            new Add_Book_Borrowing_Details().ShowDialog();
        }

        //================Add Book Issue Btn =============================
        private void borrowBookBtn_Click(object sender, EventArgs e)
        {
            new Add_Book_Borrowing_Details().ShowDialog();
        }

        //=================Return Book Btn ==============================
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

        //============Pay Member Fee =================================================
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

        //============Add Book  Dashboard Btn ======================================
        private void addBookDashBoard_Click(object sender, EventArgs e)
        {
            new AddBook().Show();
        }

        //===========Add Category Dashboard Btn ====================================
        private void addCategoryDashboard_Click(object sender, EventArgs e)
        {
            new Add_Category().Show();
        }

        //==============Add Author Dashboard Btn ====================================
        private void addAuthorDashboard_Click(object sender, EventArgs e)
        {
            new Add_Author().Show();
        }

        //========Librarian Profile Detail Update ================================

        public void profileDetailUpdate()
        {
            lbl_librarianProfileName.Text = librarian.Name;
            lbl_librarianProfileId.Text = librarian.Id;
            lbl_librarianProfileNIC.Text = librarian.NIC1;
            lbl_librarianProfileAddress.Text = librarian.Address;
            lbl_librarianProfilePhone.Text = librarian.Phone;
            
        }

        //========Librarian Logout ==============================================
        [Obsolete]
        private void btn_librariyanLogout_Click(object sender, EventArgs e)
        {
            int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 0 WHERE Emp_Id= '" + emp_Id + "'");
            if (line > 0)
            {
                this.Hide();
                Login lg = new Login();
                lg.Closed += (s, args) => this.Close();
                lg.Show();

            }
            else
            {
                MessageBox.Show("Logout Failed");
            }
        }

        //====Refresh every second =======================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_librarianDateTime.Text = DateTime.Now.ToString("yyy-MM-dd ") + DateTime.Now.ToString(" h:mm:ss tt");
        }

        private void dateTimeLibrarian_ValueChanged(object sender, EventArgs e)
        {
            lbl_BookIssuedCount.Text = tile_count("SELECT * FROM [dbo].[Book_Issue] WHERE  CONVERT(DATE, Updated_date) = '" + dateTimeLibrarian.Value.Date + "' AND Status='" + true + "'").ToString();
            lbl_BooksReturnedCount.Text = tile_count("SELECT * FROM [dbo].[Book_Issue] WHERE  CONVERT(DATE, Updated_date) = '" + dateTimeLibrarian.Value.Date + "' AND Status='" + false + "'").ToString();
        }
    }
}
