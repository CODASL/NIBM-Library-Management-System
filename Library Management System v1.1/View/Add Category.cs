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
    public partial class Add_Category : MaterialForm
    {
        Controller.CategoryController category = new Controller.CategoryController();
        public Add_Category()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            new Controller.CommonController().setId(txt_categoryId, "Category_Id", "Category", "C");
            txt_categoryName.Focus();

        }

        private void btn_addCategory_Click(object sender, EventArgs e)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                Boolean isAdded = category.addCategory(new Model.Category(txt_categoryId.Text, txt_categoryName.Text, DateTime.Now));
                if (isAdded)
                {
                    MessageBox.Show("Category Added Successfully");
                }
                else
                {
                    MessageBox.Show("Something went wrong !");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
