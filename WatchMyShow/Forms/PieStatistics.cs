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
        public PieStatistics()
        {
            InitializeComponent();
        }
        public PieStatistics(Dictionary<TvProgramGenre, int> genreStats)
        {
            InitializeComponent();
            chart1.Series.Clear();
            Series s = new Series();
            s.ChartType = SeriesChartType.Pie;
            foreach (KeyValuePair<TvProgramGenre, int> item in genreStats)
            {
                s.Points.AddXY(TvProgramManager.GetGenresAsString(item.Key), item.Value);
            }
            chart1.Series.Add(s);
        }

        private void PieStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
