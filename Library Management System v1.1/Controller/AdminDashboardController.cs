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
