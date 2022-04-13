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
    public partial class AddBook : MaterialForm
    {
        Controller.CommonController commonController = new Controller.CommonController();
        Controller.BookController bookcontroller = new Controller.BookController();
        Boolean isUpdate;
        String selectedISBN;
        MaterialLabel lastUpdate;
        public AddBook(Boolean isUpdate, String selectedISBN = null , MaterialLabel lastUpdate = null)
        {
            InitializeComponent();
            this.isUpdate = isUpdate;
            this.selectedISBN = selectedISBN;
            this.lastUpdate = lastUpdate;
        }


        //===============On load Add Book Dialog =====================

        private void AddBook_Load(object sender, EventArgs e)
        {
            onUpdate();
            new Controller.MaterialController().addStyle(this);
           
            Controller.BookController.loadComboBoxes(cmb_bookCategories, "Category", "Category_Name");
            Controller.BookController.loadComboBoxes(cmb_BookAuthors, "Author", "Author_Name");
            Controller.BookController.loadComboBoxes(cmb_bookRacks, "Rack", "Rack_NO");
            
        }


         //==================On Update ==================================
         public void onUpdate()
        {
            if (isUpdate)
            {
                this.Text = "Update Book";
                this.btn_AddBookDialog.Text = "Update";
                txt_bookISBN.ReadOnly = true;
                
                if(selectedISBN != null)
                {
                    Model.DatabaseService database = new Model.DatabaseService();
                    try
                    {
                        
                        database.Con.Open();
                        MySqlDataReader sdr = database.readData("SELECT * FROM Book WHERE ISBN = '"+selectedISBN+"'");
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            txt_bookIdAddBook.Text = sdr["BID"].ToString();
                            txt_BookName.Text = sdr["Name"].ToString();
                            txt_bookISBN.Text = sdr["ISBN"].ToString();
                            cmb_BookAuthors.SelectedText = sdr["Author"].ToString();
                            cmb_bookCategories.SelectedText = sdr["Category"].ToString();
                            cmb_bookRacks.SelectedText = sdr["Rack_No"].ToString();
                        }
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        database.Con.Close();
                    }
                }
            }
            else
            {
                commonController.setId(txt_bookIdAddBook, "BID", "Book", "B");
            }
        }

        //==================Set Value to combo box ======================
        public int setValuestoCombo(String value , MaterialComboBox cmb)
        {
            int index = 0;
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (cmb.Items[i].ToString() == value) {
                    index = i;           
                }
            }
            return index;
        }
        //================Add New Rack No ===============================
        private void addRackNoBtnAddBook_Click(object sender, EventArgs e)
        {
            new Add_RackNo(cmb_bookRacks).ShowDialog();
        }

        //================Add New Author ================================
        private void addAuthorBtnAddBook_Click(object sender, EventArgs e)
        {
            new Add_Author(cmb_BookAuthors).ShowDialog();
        }

        //================Add New Category ===============================
        private void addCategoryBtnAddBook_Click(object sender, EventArgs e)
        {
            new Add_Category(cmb_bookCategories).ShowDialog();
        }

        //=============Show ISBN QR Scanner ===========================
        private void isbnQrBtnAddBook_Click(object sender, EventArgs e)
        {
            if (this.qrPanelBookAdd.Controls.Count > 0)
                this.qrPanelBookAdd.Controls.RemoveAt(0);
            QRlogin f = new QRlogin();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            qrPanelBookAdd.Controls.Clear();
            qrPanelBookAdd.Controls.Add(f);
            qrPanelBookAdd.Tag = f;
            f.Show();

        }

        private void btn_AddBookDialog_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_bookISBN.Text == null)
                {
                    MessageBox.Show("Please Scan or type ISBN Code");
                }
                else if (txt_BookName.Text == null)
                {
                    MessageBox.Show("Please Enter Book Name");
                }
                else if (cmb_bookCategories.SelectedItem == null)
                {
                    MessageBox.Show("Please select a category");
                }
                else if (cmb_BookAuthors.SelectedItem == null)
                {
                    MessageBox.Show("Please select a author");
                }
                else if (cmb_bookRacks.SelectedItem == null)
                {
                    MessageBox.Show("Please select a book rack");
                }
                else
                {
                    Model.Book book = new Model.Book(txt_bookIdAddBook.Text,txt_BookName.Text,cmb_bookCategories.SelectedItem.ToString(),
                        cmb_BookAuthors.SelectedItem.ToString(),txt_bookISBN.Text,1.ToString(),cmb_bookRacks.SelectedItem.ToString(), DateTime.Now,DateTime.Now);
                    

                    Boolean isAdded;
                    if (!isUpdate)
                    {
                        isAdded = bookcontroller.addBook(book);
                    }
                    else
                    {
                        isAdded = bookcontroller.updateBook(book);
                    }

                    if (isAdded)
                    {
                        this.Hide();
                        if (isUpdate)
                        {
                         
                            MessageBox.Show("Record Updated");
                            Controller.CommonController.setActivity("Updated " + book.Id + " Data");
                            lastUpdate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        }
                        else
                        {
                            MessageBox.Show("Record Added");
                             Controller.CommonController.setActivity("Added New Book " + book.Id + " Data");
                            lastUpdate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong try again");
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Please check your internet connection \n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

        private void clearBtnAddBook_Click(object sender, EventArgs e)
        {
            txt_bookISBN.Clear();
            txt_BookName.Clear();
            cmb_BookAuthors.ResetText();
            cmb_bookCategories.ResetText();
            cmb_bookRacks.ResetText();
            
        }
    }
}
