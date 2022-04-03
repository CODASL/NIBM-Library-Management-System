using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Library_Management_System_v1._1.Controller
{
    class AdminDashboardController
    {
        Model.DatabaseService database = new Model.DatabaseService();

        public String setName(String emp_id)
        {
            try
            {
                database.Con.Open();
                SqlDataReader sdr = database.readData("Select Name From admin WHERE Id = '" + emp_id + "'");
                sdr.Read();
                String name =  sdr["Name"].ToString();
                database.Con.Close();
                return name;
            }
            catch (Exception ex)
            {
                database.Con.Close();
                return ex.ToString();
               
            }
        }

        

       

       //=========================Chart Codes========================================
        private Random rand = new Random(0);
        private double[] RandomWalk(int points = 5, double start = 100, double mult = 50)
        {
            // return an array of difting random numbers
            double[] values = new double[points];
            values[0] = start;
            for (int i = 1; i < points; i++)
                values[i] = values[i - 1] + (rand.NextDouble() - .5) * mult;
            return values;
        }


        public void loadCartChart(LiveCharts.WinForms.CartesianChart chart)
        {
            //chart.Series.Add(new LineSeries
            //{
            //    Values = new ChartValues { 3, 4, 6, 3, 2, 6 },
            //    StrokeThickness = 4,
            //    StrokeDashArray = new System.Windows.Media.DoubleCollection(50),
            //    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(107, 185, 79)),
            //    Fill = System.Windows.Media.Brushes.Transparent,
            //    LineSmoothness = 0,
            //    PointGeometry = null
            //});

            int pointCount = 5;
            double[] ys1 = RandomWalk(pointCount);
            double[] ys2 = RandomWalk(pointCount);

            // create series and populate them with data
            var series1 = new LiveCharts.Wpf.ColumnSeries
            {
                Title = "Group A",
                Values = new LiveCharts.ChartValues<double>(ys1)
            };

            var series2 = new LiveCharts.Wpf.ColumnSeries()
            {
                Title = "Group B",
                Values = new LiveCharts.ChartValues<double>(ys2)
            };

            // display the series in the chart control
            chart.Series.Clear();
            chart.Series.Add(series1);
            chart.Series.Add(series2);
        }

        public void loadCategoriesPieChart(LiveCharts.WinForms.PieChart pieChart)
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            LiveCharts.SeriesCollection piechartData = new LiveCharts.SeriesCollection();
            System.Windows.Media.Brush[] colors = new System.Windows.Media.Brush[5];
            colors.SetValue(System.Windows.Media.Brushes.Fuchsia , 0);
            colors.SetValue(System.Windows.Media.Brushes.DarkViolet, 1);
            colors.SetValue(System.Windows.Media.Brushes.BlueViolet, 2);
            colors.SetValue(System.Windows.Media.Brushes.CornflowerBlue, 3);
            colors.SetValue(System.Windows.Media.Brushes.Cyan, 4);
            

            for (int i = 0; i < 5; i++)
            {
                piechartData.Add(
                 new PieSeries
                 {
                     Title = "Fourth Item",
                     Values = new ChartValues<double> { 25 },
                     DataLabels = true,
                     LabelPoint = labelPoint,
                     Fill = colors[i],
                 }
             ); ;
            }
           

            // Define the collection of Values to display in the Pie Chart
            pieChart.Series = piechartData;

            // Set the legend location to appear in the bottom of the chart
            pieChart.LegendLocation = LegendLocation.Right;
        }
    }
}
