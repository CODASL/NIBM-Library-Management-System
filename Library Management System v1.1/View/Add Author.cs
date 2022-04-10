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
    public partial class Add_Author : MaterialForm
    {
        Controller.AuthorController ATR = new Controller.AuthorController();
        public Add_Author()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            new Controller.CommonController().setId(txt_authorId, "Author_ID", "Author", "");
            txt_authorName.Focus();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_authorName.Clear();
        }

        private void btn_addAuthor_Click(object sender, EventArgs e)
        {
            Model.Author author = new Model.Author(txt_authorId.Text, txt_authorName.Text, DateTime.Now);
            try
            {
                Boolean isAdded = ATR.addauthor(author);

                if (isAdded)
                {
                    this.Hide();
                   MessageBox.Show("Record Added");

                }
                else
                {
                   MessageBox.Show("Something went wrong try again");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
    }
}
