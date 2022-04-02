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

        public void setid(String textBoxData)
        {
            Model.DatabaseService obj = new Model.DatabaseService();
            String id;
            try
            {
                obj.Con.Open();
                SqlDataReader sdr = obj.readData("SELECT TOP 1 Author_ID FROM Author ORDER BY Author_ID DESC");
                sdr.Read();
                id = sdr["Author_ID"].ToString();
                obj.Con.Close();

                id = "ATR" + (Convert.ToInt32(id.Remove(0, 3)) + 1).ToString();
                textBoxData = id;

            }
            catch (SqlException ex)
            {
                MaterialMessageBox.Show(ex.Message);

            }catch(Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }

           

        }
    }
}
