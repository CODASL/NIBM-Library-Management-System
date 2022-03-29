using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class AddLibrarianController
    {
        public Boolean addLibrarian(Model.Librarian librarian)
        {
            Model.DatabaseService database = new Model.DatabaseService();

            int row = database.insertData("INSERT INTO Librarian VALUES('" + librarian.Id + "','" + librarian.Name + "','" + librarian.NIC1 + "'," +
                                "'" + librarian.Address + "','" + librarian.Email + "','" + librarian.UpdatedDate + "','" + librarian.AddedDate + "','" + librarian.Phone + "')");
            return row > 0;
        }


    }
}
