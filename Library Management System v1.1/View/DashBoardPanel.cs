﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1.View
{
    public partial class DashBoardPanel : UserControl
    {
        public DashBoardPanel()
        {
            InitializeComponent();
            metroTile1.BackColor = System.Drawing.SystemColors.MenuHighlight;
       
        }

        private void DashBoardPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
