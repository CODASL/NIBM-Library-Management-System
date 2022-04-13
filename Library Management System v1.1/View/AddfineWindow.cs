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
    public partial class AddfineWindow : MaterialForm
    {
        String MID;
        String BID;
        String Emp_Id;
        public AddfineWindow(String BID, String MID,String Emp_Id)
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            this.BID = BID;
            this.MID = MID;
            this.Emp_Id = Emp_Id;
        }

        //================On load Add Fine Window =========================================
        private void AddfineWindow_Load(object sender, EventArgs e)
        {
            txt_BIDAddFine.Text = BID;
            txt_MIDAddFine.Text = MID;
            new Controller.CommonController().setId(txt_fineId, "Fine_Id", "Fine", "F");
        }

        private void btn_PayFine_Click(object sender, EventArgs e)
        {
            try
            {
                Model.DatabaseService database = new Model.DatabaseService();
                int row = database.insertData("INSERT INTO Fine VALUES ('" + txt_fineId.Text + "','" + txt_MIDAddFine.Text + "','" + txt_BIDAddFine.Text + "','" + Emp_Id + "','" + txt_FineReason.Text + "','" + txt_fineAmount.Text + "')");
                int row1 = database.updateData("UPDATE Accounting SET Fine_Count = Fine_Count + 1 WHERE MID = '" + MID + "'");
                if (row > 0 && row1>0)
                {
                    this.Hide();
                    Controller.CommonController.setActivity("Recieved fine from " + MID + " For "+ BID +" Book");
                    MessageBox.Show("Fine paid Successfully");
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

    }
}
