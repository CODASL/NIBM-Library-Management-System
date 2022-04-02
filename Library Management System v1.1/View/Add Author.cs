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
        Controller.AddAuthorController ATR = new Controller.AddAuthorController();
        public Add_Author()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            ATR.setid(txt_authorId.Text);
            txt_authorId.Focus();
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
                    MaterialMessageBox.Show("Record Added");


                }
                else
                {
                    MaterialMessageBox.Show("Something went wrong try again");
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
    }
}
