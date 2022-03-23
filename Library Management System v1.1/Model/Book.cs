using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Model
{
    class Book
    {
        String bID;
        String name;
        String category;
        String publisher;
        String author;
        String availibility;
        String lastUpdate;
        String rackNo;
        MaterialSkin.Controls.MaterialButton btn;

       

        public Book(string bID, string name, string category, string publisher, string author, string availibility, string lastUpdate, String rackNo, MaterialButton btn)
        {
            this.bID = bID;
            this.name = name;
            this.category = category;
            this.publisher = publisher;
            this.author = author;
            this.availibility = availibility;
            this.lastUpdate = lastUpdate;
            this.rackNo = rackNo;
            this.btn = btn;
        }
    }
}
