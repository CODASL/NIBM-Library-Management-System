﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class ResponsiveController
    {

        public static int height;
        public static int width;

        public static void setResponsiveSize(Model.ResponsiveSize resSize) {
            height = resSize.height;
            width = resSize.width;
            
        }
    }
}