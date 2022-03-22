using BasselTech_CamCapture;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_v1._1
{
    public partial class QRlogin : Form
    {
        Camera cam;
        Timer t;
        BackgroundWorker worker;
        Bitmap CapImage;
        String data;
        public QRlogin()
        {
            InitializeComponent();
            t = new Timer();
            cam = new Camera(pictureBox1);
            worker = new BackgroundWorker();

            worker.DoWork += Worker_DoWork;
            t.Tick += T_Tick;
            t.Interval = 1;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            CapImage = cam.GetBitmap();
            if (CapImage != null && !worker.IsBusy)
                worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            QRCodeDecoder Decoder = new QRCodeDecoder();

            try
            {
                data = Decoder.decode(new QRCodeBitmapImage(CapImage));
                MessageBox.Show(Decoder.decode(new QRCodeBitmapImage(CapImage)));
            }
            catch (Exception)
            {

            }
        }

        private void QRlogin_Load(object sender, EventArgs e)
        {
            try
            {
                cam.Start();
                t.Start();
            }
            catch (Exception ex)
            {
                cam.Stop();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
