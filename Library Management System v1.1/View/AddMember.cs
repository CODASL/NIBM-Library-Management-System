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
    public partial class AddMember : MaterialForm
    {
        Controller.CommonController commonController = new Controller.CommonController();
        public AddMember()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            //commonController.setId(txt_mid , Member_Id)
        }
    }
}
