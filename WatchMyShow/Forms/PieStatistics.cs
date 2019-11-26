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
    public partial class PieStatistics : Form
    {
        public PieStatistics(Dictionary<TvProgramGenre, int> genreStats)
        {
            InitializeComponent();
            chart1.Series.Clear();
            Series s = new Series();
            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;
            foreach (KeyValuePair<TvProgramGenre, int> item in genreStats)
            {
                s.Points.AddXY(TvProgramManager.GetGenresAsString(item.Key), item.Value);
            }
            chart1.Series.Add(s);
            this.Text = "Legtöbbet nézett műfajok aránya";
        }
        public PieStatistics(Dictionary<string, int> channelStats)
        {
            InitializeComponent();
            chart1.Series.Clear();
            Series s = new Series();
            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;
            foreach (KeyValuePair<string, int> item in channelStats)
            {
                s.Points.AddXY(item.Key, item.Value);
            }
            chart1.Series.Add(s);
            this.Text = "Legtöbbet nézett csatornák aránya";
        }

        private void PieStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
