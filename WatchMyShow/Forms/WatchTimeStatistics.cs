using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Forms
{
    public partial class WatchTimeStatistics : Form
    {
        private TvProgramStatistics stat;
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
            Dictionary<DateTime, List<TvProgram>> s = stat.getWatchedTvPrograms(fromCalendarPicker.Value, toCalendarPicker.Value);
            Dictionary<DateTime, TimeSpan> wStat = stat.getWatchTimeStatistics(s);

            Series ser = new Series();
            ser.Name = " ";
            ser.ChartType = SeriesChartType.Column;
            ser.IsValueShownAsLabel = true;
            foreach (KeyValuePair<DateTime, TimeSpan> item in wStat)
            {

                ser.Points.AddXY(item.Key, item.Value.TotalMinutes);
            }
            chart1.Series.Clear();
            chart1.Series.Add(ser);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WatchTimeStatistics_Load(object sender, EventArgs e)
        {
        }
    }
}
