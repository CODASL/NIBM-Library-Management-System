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
        int avCount = 0;

        [Obsolete]
        public LibrariyanHome(String emp_Id)
        {
            InitializeComponent();

            material.addStyle(this);
            cmbFilterAvailability.SelectedIndex = 0;
            this.emp_Id = emp_Id;
            timer1.Start();
            this.FormClosing += Form_FormClosing;
        }
        
       //=========================On Load Librarian Home ==========================================
        private void LibrariyanHome_Load(object sender, EventArgs e)
        {
            librarian = librariyandash.setLibrariyan(emp_Id);
            lbl_librariyan_name.Text = librarian.Name.Split(' ')[0] + " " + librarian.Name.Split(' ')[1];
            lbl_welcome_note.Text = "Hello " + librarian.Name.Split(' ')[0] + ", How're you today?";
            loadDashboardTileCounts();
            loadMembers();
            loadBooks();
            loadBookIssues();
            profileDetailUpdate();
            loadAccounting();
            loadBookAvailability();
            commonController.loadActivities(listview_librarianActivities, emp_Id);
        }
        //========================load Book Availability ====================================

        public void loadBookAvailability()
        {
            listview_BookAvailability.Items.Clear();
            try
            {
                DB.Con.Open();
                MySqlDataReader sdr = DB.readData("Select * From Book");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["BID"].ToString());
                        item.SubItems.Add(sdr["Name"].ToString());
                        item.SubItems.Add(sdr["Author"].ToString());
                        if (Convert.ToBoolean(sdr["Availability"]))
                        {
                            item.SubItems.Add("Available");
                        }
                        else
                        {
                            item.SubItems.Add("Unavailable");
                        }
                        item.SubItems.Add(sdr["Rack_No"].ToString());

                        listview_BookAvailability.Items.Add(item);
                    }
                    DB.Con.Close();
                    
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
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                DB.Con.Close();
            }
        }

        //========================load Dashboard Tile Counts ===============================
        public void loadDashboardTileCounts()
        {
            lbl_members_count.Text = tile_count("SELECT * FROM Member").ToString();
            lbl_books_count.Text = tile_count("SELECT * FROM Book").ToString();
            lbl_BookIssuedCount.Text = tile_count("SELECT * FROM Book_Issue WHERE DATE(Updated_date) = '" + dateTimeLibrarian.Value.Date.ToString("yyyy-MM-dd") + "' AND Status='" + 1 + "'").ToString();
            lbl_BooksReturnedCount.Text = tile_count("SELECT * FROM Book_Issue WHERE DATE(Updated_date) = '" + dateTimeLibrarian.Value.Date.ToString("yyyy-MM-dd") + "' AND Status='" + 0 + "'").ToString();
        }

        //============ form x or F4 click logout user ================================
        [Obsolete]
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
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
        //=====================Load Member Fee table to Accounting List view =====================================
        public void loadAccounting()
        {
            accountingListview.Items.Clear();
            try
            {
                DB.Con.Open();
                MySqlDataReader sdr = DB.readData("Select * From Accounting");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["Fee_Id"].ToString());
                        item.SubItems.Add(sdr["MID"].ToString());
                        item.SubItems.Add(sdr["Fine_Count"].ToString());
                        item.SubItems.Add("Paid");
                        item.SubItems.Add(sdr["Last_Updated"].ToString());

                        memberListview.Items.Add(item);
                    }
                    DB.Con.Close();
                    lbl_AccountingLastUpdate.Text = commonController.setUpdatedTime("Last_Updated", "Accounting", "Fee_Id", "");
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
        //=====================Load Members to Member List view =====================================
        public void loadMembers()
        {
            memberListview.Items.Clear();
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

                        memberListview.Items.Add(item);
                    }
                    DB.Con.Close();
                    lbl_members_tot.Text = memberListview.Items.Count.ToString();
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
                        if (Convert.ToBoolean(sdr["Availability"]))
                        {
                            item.SubItems.Add("Available");
                            avCount = avCount + 1;
                        }
                        else
                        {
                            item.SubItems.Add("Unavailable");
                        }
                        
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
            finally
            {
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
                        if(Convert.ToBoolean(sdr["Status"]))
                        {
                            item.SubItems.Add("Issued");
                        }
                        else
                        {
                            item.SubItems.Add("Returned");
                        }
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
            finally
            {
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
            finally
            {
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

        //=================Add Book Issue Dashboard Btn =======================
        private void addBorrowDashBoardBtn_Click(object sender, EventArgs e)
        {
            if(avCount > 0)
            {
                new Add_Book_Borrowing_Details(librarian).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Books Available");
            }
            
        }

        //================Add Book Issue Btn =============================
        private void borrowBookBtn_Click(object sender, EventArgs e)
        {
            if (avCount > 0)
            {
                new Add_Book_Borrowing_Details(librarian).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Books Available");
            }
        }

        //=================Return Book Btn ==============================
        private void returnBookBtn_Click(object sender, EventArgs e)
        {
            String BID = listView_issueBooks.SelectedItems[0].SubItems[0].Text;
            String MID = listView_issueBooks.SelectedItems[0].SubItems[1].Text;
            if (listView_issueBooks.SelectedItems.Count > 0)
            {
                DialogResult dialogresult = MessageBox.Show("Have any Damages/Late return in Book ?", "", MessageBoxButtons.YesNoCancel);
                if (dialogresult.Equals(DialogResult.Yes))
                {
                    
                    new AddfineWindow(BID,MID , emp_Id).ShowDialog();

                }
                else if (dialogresult.Equals(DialogResult.No))
                {
                    Console.WriteLine(dialogresult.ToString());
                    DialogResult dialogresult1 = MessageBox.Show("Are you sure that member retured Book?", "", MessageBoxButtons.YesNo);
                    if (dialogresult1.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            Console.WriteLine(listView_issueBooks.SelectedItems[0].Index+1);
                            String ID = (listView_issueBooks.SelectedItems[0].Index + 1).ToString();
                            int row = DB.updateData("UPDATE Book_Issue SET Status = 0 WHERE ID = '" + ID + "'");
                            if(row > 0)
                            {
                                
                                int row1 = DB.updateData("UPDATE Book SET Availability = 1 WHERE BID = '" + BID + "'");
                                if (row1 > 0)
                                {
                                    MessageBox.Show("Book Returned successfully");
                                }
                                else
                                {
                                    MessageBox.Show("Book status update failed");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Book_issue status update failed");
                            }

                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        this.Hide();
                    }
                }
                else
                {
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please Select a record");
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
            new View.AddBook().ShowDialog();
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

        //===============Librarian Home Dashboard Datetimepicker Controller ==============================
        private void dateTimeLibrarian_ValueChanged(object sender, EventArgs e)
        {

            lbl_BookIssuedCount.Text = tile_count("SELECT * FROM Book_Issue WHERE DATE(Updated_date) = '" + dateTimeLibrarian.Value.Date + "' AND Status='" + 1 + "'").ToString();
            lbl_BooksReturnedCount.Text = tile_count("SELECT * FROM Book_Issue WHERE DATE(Updated_date) = '" + dateTimeLibrarian.Value.Date + "' AND Status='" + 0 + "'").ToString();
        }


        //================Update Member Btn===================================================
        private void btn_updateMember_Click(object sender, EventArgs e)
        {
            try
            {
                String selectedRowId = memberListview.SelectedItems[0].SubItems[0].Text;
                new AddMember(true, selectedRowId).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //===================Delete Member Btn ========================================
        private void btn_deleteMember_Click(object sender, EventArgs e)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            DialogResult res = MessageBox.Show("Are you sure ?", "", MessageBoxButtons.YesNo);
            if (res.Equals(DialogResult.Yes))
            {
                ListView.SelectedIndexCollection selectedIndex = memberListview.SelectedIndices;
                if (selectedIndex.Count > 0)
                {
                    foreach (int index in selectedIndex)
                    {
                        Console.WriteLine(index);

                    }
                    String selectedRowId = memberListview.SelectedItems[0].SubItems[0].Text;

                    try
                    {
                        int line = database.deleteData("DELETE FROM Member WHERE MID = '" + selectedRowId + "'");

                        int line1 = database.deleteData("DELETE FROM Guardian WHERE GID = (SELECT GID FROM Member WHERE MID = '" + selectedRowId + "')");

                        if (line > 0 && line1 > 0)
                        {
                            MessageBox.Show("Member Removed Successfully");
                            loadMembers();
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong");
                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("No Rows Selected");

                }
            }
            else
            {
                MessageBox.Show("Deletation Cancelled");
            }
        }
    }
}
