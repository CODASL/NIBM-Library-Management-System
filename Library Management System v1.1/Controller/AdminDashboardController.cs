using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using MaterialSkin.Controls;
using System.Windows.Forms;
using System.Windows;


namespace Library_Management_System_v1._1.Controller
{
    class AdminDashboardController
    {
        static Model.DatabaseService database = new Model.DatabaseService();

        public static void loadLibrariyanList(MaterialListView listView , MaterialLabel NOF)
        {
            listView.Items.Clear();
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select * From Librarian");
                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        ListViewItem item = new ListViewItem(sdr["Librarian_Id"].ToString());
                        item.SubItems.Add(sdr["Name"].ToString());
                        item.SubItems.Add(sdr["Address"].ToString());
                        item.SubItems.Add(sdr["Phone"].ToString());
                        item.SubItems.Add(sdr["NIC"].ToString());
                        item.SubItems.Add(sdr["updated_date"].ToString());

                        listView.Items.Add(item);
                    }
                    database.Con.Close();
                    NOF.Text = listView.Items.Count.ToString();
                    

                }
                else
                {
                    Console.WriteLine("No Data to Show");
                    database.Con.Close();
                }

            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                database.Con.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                database.Con.Close();
            }

        }

        //=============Search Function ==========================

        public void searchFunction(MaterialListView list, int itemIndex, MaterialTextBox inputBox)
        {
          
                if (itemIndex == 0)
                {

                    for (int i = list.Items.Count - 1; i >= 0; i--)
                    {
                        var item = list.Items[i];

                        if (item.Text.ToLower().Contains(inputBox.Text.ToLower()))
                        {

                        }
                        else
                        {
                            list.Items.Remove(item);
                        }
                    }
                    if (list.SelectedItems.Count == 1)
                    {
                        list.Focus();
                    }
                }
                else if(itemIndex == 1)
                {
                    for (int i = list.Items.Count - 1; i >= 0; i--)
                    {
                        var item = list.Items[i];

                        if (item.SubItems[1].Text.ToLower().Contains(inputBox.Text.ToLower()))
                        {

                        }
                        else
                        {
                            list.Items.Remove(item);
                        }
                    }
                    if (list.SelectedItems.Count == 1)
                    {
                        list.Focus();
                    }

                }
                else
                {

                }

        }

        //=============Set Notification Count Label==============
        public String setNotificationCount()
        {
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select * FROM Notification WHERE Status = ''");
                int count = 0;
                while (sdr.Read())
                {
                    count = count + 1;
                }

                database.Con.Close();
                return count.ToString();
            }catch(MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                
            }catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                database.Con.Close();
            }
            return "";
        }

        //============Set Admin Name ============================
        public String setName(String emp_id)
        {
            try
            {
                database.Con.Open();
                MySqlDataReader sdr = database.readData("Select Name From Admin WHERE emp_id = '" + emp_id + "'");
                sdr.Read();
                String name =  sdr["Name"].ToString();
                database.Con.Close();
                return name;
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                database.Con.Close();
            }
            return "";
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
            Model.DatabaseService database = new Model.DatabaseService();

            LiveCharts.SeriesCollection piechartData = new LiveCharts.SeriesCollection();
            System.Windows.Media.Brush[] colors = new System.Windows.Media.Brush[5];
            colors.SetValue(System.Windows.Media.Brushes.Fuchsia , 0);
            colors.SetValue(System.Windows.Media.Brushes.DarkViolet, 1);
            colors.SetValue(System.Windows.Media.Brushes.BlueViolet, 2);
            colors.SetValue(System.Windows.Media.Brushes.CornflowerBlue, 3);
            colors.SetValue(System.Windows.Media.Brushes.Cyan, 4);


            setPiechartData(piechartData, labelPoint, colors);
           

            // Define the collection of Values to display in the Pie Chart
            pieChart.Series = piechartData;

            // Set the legend location to appear in the bottom of the chart
            pieChart.LegendLocation = LegendLocation.Right;
        }

        //===================Get Category Count ===================

        public int setBookCount()
        {
            int a = 0;
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                database.Con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Count(*) FROM Book", database.Con);
                a = Convert.ToInt32( cmd.ExecuteScalar().ToString());
                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                database.Con.Close();
            }
            return a;
        }

        

        //==============
        public void setPiechartData(LiveCharts.SeriesCollection piechartData, Func<ChartPoint, string> labelPoint, System.Windows.Media.Brush[] colors)
        {
            Model.DatabaseService database = new Model.DatabaseService();
            try
            {
                int i = 0;
                database.Con.Open();
                MySqlDataReader sdr = database.readData("SELECT * FROM Category");
                while (sdr.Read())
                {
                 piechartData.Add(
                    new PieSeries
                    {
                        Title = sdr["Category_Name"].ToString(),
                        Values = new ChartValues<double> {(Convert.ToInt32(sdr["Book_Count"])/setBookCount())*100},
                        DataLabels = true,
                        LabelPoint = labelPoint,
                        Fill = colors[i],
                        
                    }

                  );
                  i = i + 1;
                }
                

            }
            catch(Exception ex)
            {

            }
            finally
            {
                database.Con.Close();
            }
        }
    }
}
