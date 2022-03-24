using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Controller
{
    class MaterialController
    {
        MaterialSkinManager.Themes   thememode = MaterialSkinManager.Themes.LIGHT;

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public MaterialSkinManager.Themes Thememode { get => thememode; set => thememode = value; }
        public MaterialSkinManager MaterialSkinManager { get => materialSkinManager; set => materialSkinManager = value; }

        public  void addStyle(MaterialForm form)
        {
            MaterialSkinManager.AddFormToManage(form);
            MaterialSkinManager.Theme = Thememode;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            
        }
    }
}
