
using LiveCharts;
using LiveCharts.Wpf;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
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
    public partial class AdminDashboard :MaterialForm
    {

        Controller.AdminDashboardController adminDashboardCtrl = new Controller.AdminDashboardController();
        public AdminDashboard()
        {
            InitializeComponent();
            new Controller.MaterialController().addStyle(this);
            
            todayDateAdmin.Text = DateTime.Now.ToString();
            adminDashboardCtrl.loadCategoriesPieChart(categoriesPieChart);



        }

        private void pieChartOnLoad()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection piechartData = new SeriesCollection
{
            new PieSeries
            {
                Title = "First Item",
                 Values = new ChartValues<double> {25},
                DataLabels = true,
                LabelPoint = labelPoint,

                // Define a custom Color 
                Fill = System.Windows.Media.Brushes.Black
            },
            new PieSeries
            {
                Title = "Second Item",
                Values = new ChartValues<double> {25},
                DataLabels = true,
                LabelPoint = labelPoint,
                Fill = System.Windows.Media.Brushes.Green,
                PushOut = 0
            },
            new PieSeries
            {
                Title = "Third Item",
                Values = new ChartValues<double> {25},
                DataLabels = true,
                LabelPoint = labelPoint,
                Fill = System.Windows.Media.Brushes.Pink
            }
         };

            // You can add a new item dinamically with the add method of the collection
            piechartData.Add(
                new PieSeries
                {
                    Title = "Fourth Item",
                    Values = new ChartValues<double> { 25 },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Gray
                }
            );

            // Define the collection of Values to display in the Pie Chart
            categoriesPieChart.Series = piechartData;

            // Set the legend location to appear in the bottom of the chart
            categoriesPieChart.LegendLocation = LegendLocation.Right;
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void materialListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void adminNotifications_Click(object sender, EventArgs e)
        {
            new AdminNotifications().ShowDialog();
        }
    }
}
