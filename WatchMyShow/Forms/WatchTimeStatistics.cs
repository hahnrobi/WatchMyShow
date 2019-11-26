using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Forms
{
    public partial class WatchTimeStatistics : Form
    {
        TvProgramStatistics stat;
        public WatchTimeStatistics()
        {
            InitializeComponent();
            stat = new TvProgramStatistics();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<DateTime, List<TvProgram>> s = stat.getWatchedTvPrograms(this.fromCalendarPicker.Value, this.toCalendarPicker.Value);
            Dictionary<DateTime, TimeSpan> wStat = stat.getWatchTimeStatistics(s);


            foreach (KeyValuePair<DateTime, List<TvProgram>> item in s)
            {
                Console.WriteLine("Dátum: " + item.Key);
                foreach (TvProgram program in item.Value)
                {
                    Console.WriteLine(program.Title);
                }
            }
            Series ser = new Series();
            ser.Name = " ";
            ser.ChartType = SeriesChartType.Column;
            ser.IsValueShownAsLabel = true;
            foreach (KeyValuePair<DateTime, TimeSpan> item in wStat)
            {
                
                ser.Points.AddXY(item.Key, item.Value.TotalMinutes);
            }
            this.chart1.Series.Clear();
            this.chart1.Series.Add(ser);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WatchTimeStatistics_Load(object sender, EventArgs e)
        {
        }
    }
}
