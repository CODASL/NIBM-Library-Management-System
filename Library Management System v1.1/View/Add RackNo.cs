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
        }
    }
}
