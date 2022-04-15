using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Management_System_v1._1.Controller
{
    class LibrariyanDashboardController
    {
        static Model.DatabaseService db = new Model.DatabaseService();
        public static List<Model.Member> members;
        public static List<Model.Book> books;
        public static List<Model.BookIssue> bookIssue;
        public static Model.Librarian librarian;
        public static List<Model.MemberFee> accounting;
        

        public static void loadMembers()
        {
            members = new List<Model.Member>();
            db.Con.Open();
            MySqlDataReader sdr = db.readData("SELECT * FROM Member");
            while (sdr.Read())
            {
                if (sdr.HasRows)
                {
                    members.Add(
                        new Model.Member(
                            sdr["MID"].ToString(),
                            sdr["Name"].ToString(),
                            sdr["Address"].ToString(), 
                            sdr["Phone_No"].ToString(),
                            sdr["NIC"].ToString(),
                            sdr["Guardian_Id"].ToString(),
                            Convert.ToDateTime(sdr["Updated_date"]),
                            Convert.ToDateTime(sdr["Date_Added"])
                        )
                    );
                }
            }
            db.Con.Close();
        }


        public Model.Librarian setLibrariyan(String emp_id)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            Model.Librarian librarian;
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select * From Librarian WHERE Librarian_Id = '" + emp_id + "'");
                sdr.Read();
                if (sdr.HasRows)
                {
                    librarian = new Model.Librarian(
                        emp_id, sdr["Name"].ToString(), sdr["Address"].ToString(), sdr["Email"].ToString(),
                        sdr["NIC"].ToString(), sdr["Phone"].ToString(),Convert.ToDateTime(sdr["updated_date"]),
                        Convert.ToDateTime(sdr["date_added"]));
                }
                else
                {
                    librarian = null;
                }
                database.Con.Close();
                return librarian;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                MessageBox.Show(ex.Message);
                database.Con.Close();
                return null;

            }
            finally
            {
                database.Con.Close();
            }

        }
    }
}
