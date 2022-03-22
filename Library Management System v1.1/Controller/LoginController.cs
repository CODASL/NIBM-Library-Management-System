using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.Controller
{
    class LoginController
    {

        public void onLoggedIn(Form nextFrom , String cu) {

            SplashController.setIsLoggedIn(true , cu);
            nextFrom.Show();
        }
    }
}
