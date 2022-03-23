using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.View
{
    public partial class BookItemTile : Component
    {
        public BookItemTile()
        {
            InitializeComponent();
        }

        public BookItemTile(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
