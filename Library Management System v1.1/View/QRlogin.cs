﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using MySql.Data.MySqlClient;

namespace Library_Management_System_v1._1
{
    public partial class QRlogin : Form
    {
        FilterInfoCollection getdata;
        VideoCaptureDevice camera;
        Model.DatabaseService database = new Model.DatabaseService();
        Controller.LoginController loginController = new Controller.LoginController();


        public QRlogin()
        {
            InitializeComponent();
            getdata = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in getdata)
            {
                comboBox1.Items.Add(info.Name);
                comboBox1.SelectedIndex = 0;
            }

            

        }

        private void Camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void QRlogin_Load(object sender, EventArgs e)
        {
            try
            {
                camera = new VideoCaptureDevice(getdata[comboBox1.SelectedIndex].MonikerString);
                camera.NewFrame += Camera_NewFrame;
                camera.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                camera.Stop();
                MessageBox.Show(ex.Message);
            }

        }
        private void load(object sender, EventArgs e)
        {
            this.Hide();
            Login f1 = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (f1 != null)
            {
                f1.Hide();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader br = new BarcodeReader();

                        Result ans = br.Decode((Bitmap) pictureBox1.Image);

                        if (ans != null)
                        {
                            String emp_id;
                            database.Con.Open();
                            emp_id = ans.ToString();
                            MySqlDataReader sdr = database.readData("Select * From AppUser where Emp_Id = '" + ans.ToString() + "'");
                            sdr.Read();
                            if (sdr.HasRows)
                            {
                                int line = new Model.DatabaseService().updateData("Update AppUser SET IsLoggedIn = 1 WHERE Emp_Id= '" + emp_id + "'");
                                if (line > 0)
                                {
                                    database.Con.Close();
                                    timer1.Stop();
                                    camera.Stop();
                                    var lg = new View.LibrariyanHome(emp_id);
                                    lg.Shown += load;
                                    lg.Show();
                                }
                            }
                            else
                            {
                                database.Con.Close();
                                MessageBox.Show("user Does not exist ", MessageBoxIcon.Warning.ToString());
                            }
                        }
                    }

                }


    }
}
