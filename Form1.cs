using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NastyLaba
{
    public partial class Form1 : Form
    {
        List<Data> datas;
        public Form1()
        {
            InitializeComponent();
        }
        public class Algoritm
        {
            public void FirstEx(int n)
            {
                Random rand = new Random();
                int[] array = new int[n];
                ulong even = 0;
                ulong notEven = 0;
                for (int i = 0; i < n; i++)
                {
                    array[i] = rand.Next(10000000, 50000000);
                }
                for (int i = 0; i < n; i++)
                {
                    if (array[i]%2 == 0)
                    {
                        even += (ulong)array[i];
                    }
                    else
                    {
                        notEven += (ulong)array[i];
                    }
                }
            }
        }
        public class Data
        {
            public int values { get; set; }
            public double time { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            datas = new List<Data>();
            Algoritm alg = new Algoritm();
            for (int i = 10000000; i < 50000000; i += 5000000)
            {
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                alg.FirstEx(i);
                startTime.Stop();
                datas.Add(new Data { values = i, time = startTime.ElapsedMilliseconds });
            }

            SeriesCollection series = new SeriesCollection();
            ChartValues<int> zp = new ChartValues<int>();
            List<string> date = new List<string>();
            foreach (var item in datas)
            {
                zp.Add((int)item.time);
                date.Add(item.values.ToString());
            }
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Количество",
                Labels = date
            });

            LineSeries line = new LineSeries();
            line.Title = "";
            line.Values = zp;

            series.Add(line);
            cartesianChart1.Series = series;
        }
    }
}
