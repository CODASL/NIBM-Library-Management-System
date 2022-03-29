using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Model
{
    class Librarian
    {
        String id;
        String name;
        String address;
        String email;
        String updatedDate;
        String addedDate;

        public Librarian(string id, string name, string address, string email, string updatedDate, string addedDate)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.updatedDate = updatedDate;
            this.addedDate = addedDate;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string UpdatedDate { get => updatedDate; set => updatedDate = value; }
        public string AddedDate { get => addedDate; set => addedDate = value; }
    }
}
