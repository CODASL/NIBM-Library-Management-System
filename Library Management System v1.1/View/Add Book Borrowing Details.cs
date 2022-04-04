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
    public partial class Add_Book_Borrowing_Details : MaterialForm
    {
        public Add_Book_Borrowing_Details()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
           
        }

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
    }
}
