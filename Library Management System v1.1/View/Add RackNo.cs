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
    public partial class Add_RackNo : MaterialForm
    {
        public Add_RackNo()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            new Controller.CommonController().setId(txt_rackId, "Rack_Id", "Rack", "R");
        }

        private void btn_AddRackNo_Click(object sender, EventArgs e)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                int row = database.insertData("INSERT INTO Rack VALUES('" + txt_rackId.Text + "','" + txt_rackNo.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                if (row > 0)
                {
                    MessageBox.Show("Rack No Added Successfully");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
