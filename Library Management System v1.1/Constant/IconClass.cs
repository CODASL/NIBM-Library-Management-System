using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Constant
{
    class IconClass
    {
        static String exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        
        public String dashboardbtnLight = exePath+ "\\Images\\dashboardLight.png";
        public String dashboardbtnDark = exePath + "\\Images\\dashboardIco.png";
        public String manageUsersbtnLight = exePath + "\\Images\\usersLight.png";
        public String manageUsersbtnDark = exePath + "\\Images\\usersDak.png";
        public String manageBooksbtnLight = exePath + "\\Images\\booksLight.png";
        public String manageBooksbtnDark = exePath + "\\Images\\booksDark.png";
        public String manageFeebtnLight = exePath + "\\Images\\feeLight.png";
        public String manageFeebtnDark = exePath + "\\Images\\feeDark.png";
        public String manageActivitiesbtnLight = exePath + "\\Images\\activityLight.png";
        public String manageActivitiesbtnDark = exePath + "\\Images\\activityDark.png";
        public String showPass = exePath + "\\Images\\showPass.png";
        public String hidePass = exePath + "\\Images\\hidePass.png";


    }
}
