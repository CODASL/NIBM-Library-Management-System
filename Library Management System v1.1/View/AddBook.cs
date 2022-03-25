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
    public partial class AddBook : MaterialForm
    {
        public AddBook()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }

        private void materialTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void startQrCameraBookAdd_Click(object sender, EventArgs e)
        {
            if (this.qrPanelBookAdd.Controls.Count > 0)
                this.qrPanelBookAdd.Controls.RemoveAt(0);
            QRlogin f = new QRlogin();
            f.TopLevel = false;
            f.Dock = Dock;
            qrPanelBookAdd.Controls.Clear();
            qrPanelBookAdd.Controls.Add(f);
            qrPanelBookAdd.Tag = f;
            f.Show();
        }
    }
}
