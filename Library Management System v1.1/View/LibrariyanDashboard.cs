using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Library_Management_System_v1._1.View
{
    public partial class LibrariyanDashboard : MetroFramework.Forms.MetroForm
    {
        Controller.LibrariyanHomeController librariyanHomeCtrl = new Controller.LibrariyanHomeController();
        Constant.IconClass iconClass = new Constant.IconClass();
        public LibrariyanDashboard()
        {
            InitializeComponent();
            onChangeNavigation(0, contextPanel, new DashBoardPanel());

        }
        private void onChangeNavigation(int arrayIndex , Panel where , UserControl from )
        {
            

            Model.SideBarNavigateBtn[] sideBarBtns = new Model.SideBarNavigateBtn[5];
            sideBarBtns.SetValue(new Model.SideBarNavigateBtn(iconClass.dashboardbtnLight , iconClass.dashboardbtnDark , btnDashboard),0);
            sideBarBtns.SetValue(new Model.SideBarNavigateBtn(iconClass.manageUsersbtnLight, iconClass.manageUsersbtnDark, btnManageUsers), 1);
            sideBarBtns.SetValue(new Model.SideBarNavigateBtn(iconClass.manageBooksbtnLight , iconClass.manageBooksbtnDark , btnManageCustomers), 2);
            sideBarBtns.SetValue(new Model.SideBarNavigateBtn(iconClass.manageFeebtnLight, iconClass.manageFeebtnDark, btnManageFee), 3);
            sideBarBtns.SetValue(new Model.SideBarNavigateBtn(iconClass.manageActivitiesbtnLight, iconClass.manageActivitiesbtnDark, myActivitiesBtn), 4);


            Console.WriteLine(sideBarBtns[0].darkIcon);
            for (int i = 0; i < sideBarBtns.Length; i++)
            {
                sideBarBtns[i].isClicked = false;
            }
            sideBarBtns[arrayIndex].isClicked = true;


            for(int i = 0; i < sideBarBtns.Length; i++)
            {
                if (sideBarBtns[i].isClicked)
                {
                   
                    librariyanHomeCtrl.setUI(where, from);
                    sideBarBtns[i].btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
                    sideBarBtns[i].btn.ForeColor = System.Drawing.Color.White;
                    sideBarBtns[i].btn.Image = Image.FromFile(sideBarBtns[i].lightIcon);
                }
                else
                {
                    sideBarBtns[i].btn.BackColor = System.Drawing.Color.White;
                    sideBarBtns[i].btn.ForeColor = System.Drawing.Color.Black;
                    sideBarBtns[i].btn.Image = Image.FromFile(sideBarBtns[i].darkIcon);
                }
            }

            
           

            

        }

       
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            onChangeNavigation(0,contextPanel, new DashBoardPanel());
           
        }


        private void btnManageUsers_Click(object sender, EventArgs e)
        {
           
            onChangeNavigation(1,contextPanel, new UserManagement());
        
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            onChangeNavigation(2,contextPanel, new ManageBookLibrarian());
            
        }

        private void btnManageFee_Click(object sender, EventArgs e)
        {
            onChangeNavigation(3,contextPanel, new DashBoardPanel());
      
        }

        private void myActivitiesBtn_Click(object sender, EventArgs e)
        {
            onChangeNavigation(4,contextPanel, new DashBoardPanel());
            
        }


        Point lastPoint;
       private void LibrariyanDashboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void LibrariyanDashboard_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
