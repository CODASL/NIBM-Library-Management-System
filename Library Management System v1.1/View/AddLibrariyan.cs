using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.View
{
    public partial class AddLibrariyan : MaterialForm
    {
        Controller.AddLibrarianController addLibrarianObj = new Controller.AddLibrarianController();
        public AddLibrariyan()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
        }

        private void addLibrariyanDialogBtn_Click(object sender, EventArgs e)
        {
            Model.Librarian librarian = new Model.Librarian(txt_LibID.Text, txt_LibName.Text, txt_LibAddress.Text, txt_LibEmail.Text,
                    txt_LibNIC.Text, txt_LibPhone.Text, DateTime.Now, DateTime.Now);

            Model.User appUser = new Model.User(txt_LibID.Text , txt_LibID+"123" ,"Admin",false);
           
            try
            {
              Boolean isAdded =  addLibrarianObj.addLibrarian(librarian , appUser);

                if (isAdded)
                {
                    this.Hide();
                    MessageBox.Show("Record Added");
                    new AdminDashboard().loadLibrariyanList();
                }
                else
                {
                    MessageBox.Show("Something went wrong try again");
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void clearLibrarianBtnDialog_Click(object sender, EventArgs e)
        {
            txt_LibID.Clear();
            txt_LibName.Clear();
            txt_LibAddress.Clear();
            txt_LibEmail.Clear();
            txt_LibNIC.Clear();
            txt_LibPhone.Clear();
        }
    }
}
