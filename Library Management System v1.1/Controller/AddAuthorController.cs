using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class AddAuthorController
    {
        public Boolean addauthor(Model.Author author)
        {
            Model.DatabaseService db = new Model.DatabaseService();

            int row = db.insertData("INSERT INTO Author VALUES('" + author.Id + "','" + author.Name + "','" + author.AddedDate + "')");

            return row > 0;
        }

        public String setid()
        {
            Model.DatabaseService obj = new Model.DatabaseService();
            String id = "ATR1";
            try
            {
                obj.Con.Open();
                SqlDataReader sdr = obj.readData("SELECT TOP 1 Author_ID FROM Author ORDER BY Author_ID DESC");
                sdr.Read();
                if (sdr.HasRows)
                {
                    id = sdr["Author_ID"].ToString();
                    id = "ATR" + (Convert.ToInt32(id.Remove(0, 3)) + 1).ToString();
                    obj.Con.Close();
                }

                obj.Con.Close();
                return id;

            }
            catch (SqlException ex)
            {
                MaterialMessageBox.Show(ex.Message);

            }catch(Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }

            return id;

        }
    }
}
