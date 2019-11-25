using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WatchMyShow.DataClasses;
using WatchMyShow.Forms;

namespace WatchMyShow
{
    public partial class MainWindow : Form
    {
        TvProgramManager tvProgramManager;
        TvProgramStatistics TvProgramStatistics;
        public MainWindow()
        {
            InitializeComponent();
            tvProgramManager = new TvProgramManager();
            TvProgramStatistics = new TvProgramStatistics();
        }
        
        private void MainWindow_Load(object sender, EventArgs e)
        {
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            
            tvProgramManager.ImportTvPrograms("tv.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
                TvProgramBrowser tpb = new TvProgramBrowser();
                tpb.Show();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            RoomManagingForm rmf = new RoomManagingForm();
            rmf.Show();
        }

        private void dsadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> stat = (Dictionary<string, int>)TvProgramStatistics.getStatistics(Stats.ByTvChannel);
            PieStatistics ps = new PieStatistics(stat);
            ps.ShowDialog();
        }

        private void műsorokKezeléseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TvProgramManageForm TvPMF = new TvProgramManageForm();
            TvPMF.ShowDialog();
        }

        private void szobaKezelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomManagingForm rmf = new RoomManagingForm();
            rmf.ShowDialog();
        }

        private void bezárásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
