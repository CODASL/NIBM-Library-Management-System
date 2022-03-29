using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.Controller
{
   
    class LoginController
    {
        public static String currentUserId;
        [Obsolete]
        public void onLoggedIn(SqlDataReader sdr , String password , Form form) {


            if (sdr.HasRows)
            {

                if (sdr["Password"].ToString() == password)
                {
                    String emp_id = sdr["Emp_Id"].ToString();
                    
                    int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 1 Where Emp_Id = '" + emp_id + "'");
                    if (line > 0)
                    {
                        form.Hide();
                        
                        if (sdr["Emp_Type"].ToString() == "Admin")
                        {
                            
                            new View.AdminDashboard(emp_id).Show();
                            currentUserId = emp_id;
                            
                        }
                        else
                        {
                            new View.LibrariyanHome(emp_id).Show();
                            currentUserId = emp_id;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong please try again");
                    }   
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }

            }
            else
            {
                MessageBox.Show("This user doesn't exists. please check again");
            }
        }
    }
}
