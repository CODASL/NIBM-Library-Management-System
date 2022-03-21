using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.Model
{
    class SideBarNavigateBtn
    {
        public String lightIcon;
        public String darkIcon;
        public Button btn;
        public bool isClicked;

        public SideBarNavigateBtn(string lightIcon, string darkIcon, Button btn , bool isClicked = false)
        {
            this.lightIcon = lightIcon;
            this.darkIcon = darkIcon;
            this.btn = btn;
            this.isClicked = isClicked;
        }
    }
}
