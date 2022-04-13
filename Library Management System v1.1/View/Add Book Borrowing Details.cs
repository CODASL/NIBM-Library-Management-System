using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
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
    public partial class Add_Book_Borrowing_Details : MaterialForm
    {
        Controller.CommonController commonController = new Controller.CommonController();
        Model.Librarian librarian;
        String BID;
        public Add_Book_Borrowing_Details(Model.Librarian librarian)
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            this.librarian = librarian;
        }

        //=================Book Issue On Load ==============================
        private void Add_Book_Borrowing_Details_Load(object sender, EventArgs e)
        {
            
            commonController.setId(txt_issueId, "ID", "Book_Issue", "");
            cmb_ISBN.Focus();
            loadISBNData();
            loadMemberData();
            txt_issuingLibId.Text = librarian.Id;
            lbl_LibName.Text = librarian.Name;
           
        }


        //===================Load ISBN DATA =================================
        private void loadISBNData()
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Book WHERE Availability = 1");
                while (sdr.Read())
                {
                    cmb_ISBN.Items.Add(sdr["ISBN"]);
                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
        }
        //===================Load Member DATA =================================
        private void loadMemberData()
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Member");
                while (sdr.Read())
                {
                    cmb_MemberId.Items.Add(sdr["MID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
        }
        //==================Load ISBN Barcode =============================
        private void isbnQrBtnissueBook_Click(object sender, EventArgs e)
        {
            if (this.qrPanelBookBorrow.Controls.Count > 0)
                this.qrPanelBookBorrow.Controls.RemoveAt(0);
            QRlogin f = new QRlogin();
            f.TopLevel = false;
            f.Dock = Dock;
            qrPanelBookBorrow.Controls.Clear();
            qrPanelBookBorrow.Controls.Add(f);
            qrPanelBookBorrow.Tag = f;
            f.Show();
        }

        //==================Load MemberID QR =============================
        private void memberIdbtnIssueBook_Click(object sender, EventArgs e)
        {
            if (this.qrPanelBookBorrow.Controls.Count > 0)
                this.qrPanelBookBorrow.Controls.RemoveAt(0);
            QRlogin f = new QRlogin();
            f.TopLevel = false;
            f.Dock = Dock;
            qrPanelBookBorrow.Controls.Clear();
            qrPanelBookBorrow.Controls.Add(f);
            qrPanelBookBorrow.Tag = f;
            f.Show();
        }

        //==============GET Book Details By ISBN =============================
        private void cmb_ISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Book WHERE ISBN = '"+cmb_ISBN.SelectedItem+"'");
                sdr.Read();
                lbl_bookName.Text = sdr["Name"].ToString();
                lbl_bookCategory.Text = sdr["Category"].ToString();
                lbl_BookAuthor.Text = sdr["Author"].ToString();
                BID = sdr["BID"].ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
        }

        //==============GET Member Details By Member ID =============================
        private void cmb_MemberId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Member WHERE MID = '" + cmb_MemberId.SelectedItem + "'");
                sdr.Read();
                lbl_MemberName.Text = sdr["Name"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
        }

        private void btn_issueBookDialog_Click(object sender, EventArgs e)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                int row = database.insertData("INSERT INTO Book_Issue VALUES('" + txt_issueId.Text + "','" + BID + "','" + cmb_MemberId.SelectedItem + "','" + txt_issuingLibId.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.AddDays(14).ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + 1 + "')");
                if(row > 0)
                {
                    int row1 = database.updateData("UPDATE Book SET Availability = 0 WHERE BID = '" + BID + "'");
                    if(row1 > 0)
                    {
                        this.Hide();
                        Controller.CommonController.setActivity("Added " + txt_issueId + " Book Issue");
                        MessageBox.Show("Book Issue Data Added Successfully");
                        
                    }
                    else
                    {
                        MessageBox.Show("Something went Wrong");
                    }
                }
                else
                {
                    MessageBox.Show("Something went Wrong");
                }
                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_clearissueBookDialog_Click(object sender, EventArgs e)
        {
            cmb_ISBN.ResetText();
            cmb_MemberId.ResetText();
        }
    }
}
