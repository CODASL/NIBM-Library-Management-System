﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Model
{
    class Category
    {
        String id;
        String name;
        String dateAdded;

        public Category(string id, string name, string dateAdded)
        {
            this.id = id;
            this.name = name;
            this.dateAdded = dateAdded;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string DateAdded { get => dateAdded; set => dateAdded = value; }
    }
}
