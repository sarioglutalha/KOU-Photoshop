using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAZLAB._03
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int[] redd = new int[256];
        int[] g = new int[256];
        int[] b = new int[256];

        private void button1_Click(object sender, EventArgs e)
        {
            dosyadanOku();
            chart1.Series.Clear();
            chart1.Series.Add("RED");
            chart1.Series["RED"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series.Add("GREEN");
            chart1.Series["GREEN"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series.Add("BLUE");
            chart1.Series["BLUE"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series["RED"].Color = Color.Red;
            chart1.Series["GREEN"].Color = Color.Green;
            chart1.Series["BLUE"].Color = Color.Blue;
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["RED"].Points.Add(redd[i]);
                chart1.Series["GREEN"].Points.Add(g[i]);
                chart1.Series["BLUE"].Points.Add(b[i]);

            }
        }

        public void dosyadanOku()
        {
            for (int k = 0; k < 256; k++)
            {
                redd[k] = 0;
                b[k] = 0;
                g[k] = 0;
            }
            string[] temp = new string[4];
            FileStream fs = new FileStream("C:\\histogram\\x.txt", FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                temp = yazi.Split('-');
                int v_red = Convert.ToInt32(temp[0]);
                int v_green = Convert.ToInt32(temp[1]);
                int v_blue = Convert.ToInt32(temp[2]);

                redd[v_red]++;
                g[v_green]++;
                b[v_blue]++;

                yazi = sw.ReadLine();
            }
            sw.Close();
            fs.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dosyadanOku();
            chart1.Series.Clear();
            chart1.Series.Add("RED");
            chart1.Series["RED"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series["RED"].Color = Color.Red;
            for (int i = 0; i < 256; i++)
            {
                
                chart1.Series["RED"].Points.Add(redd[i]);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dosyadanOku();
            chart1.Series.Clear();
            chart1.Series.Add("GREEN");
            chart1.Series["GREEN"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series["GREEN"].Color = Color.Green;
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["GREEN"].Points.Add(g[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dosyadanOku();
            chart1.Series.Clear();
            chart1.Series.Add("BLUE");
            chart1.Series["BLUE"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series["BLUE"].Color = Color.Blue;
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["BLUE"].Points.Add(b[i]);
            }
        }
    }
}
