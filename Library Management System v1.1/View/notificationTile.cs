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
    public partial class notificationTile : UserControl
    {
        public notificationTile(String LibId , String reason , String dateTime)
        {
            InitializeComponent();
            lbl_LibId.Text = LibId;
            lbl_Reason.Text = reason;
            lbl_recievedTime.Text = dateTime;
        }
    }
}
