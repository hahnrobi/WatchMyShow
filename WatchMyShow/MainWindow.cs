using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using WatchMyShow.Event;
using WatchMyShow.Forms;

namespace WatchMyShow
{
    public partial class MainWindow : Form
    {
        private TvProgramManager tvProgramManager;
        private TvProgramStatistics TvProgramStatistics;
        private Countdown countdown;
        public MainWindow()
        {
            InitializeComponent();
            tvProgramManager = new TvProgramManager();
            TvProgramStatistics = new TvProgramStatistics();
            countdown = new Countdown();
            countdown.ProgramIncoming += DisplayAlert;
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
            Dictionary<string, int> stat = (Dictionary<string, int>)TvProgramStatistics.getPieStatistics(Stats.ByTvChannel);
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
            Close();
        }
        private void DisplayAlert(object sender, TvProgramIncomingEventArgs args)
        {
            TvProgramAlert alert = new TvProgramAlert(args.TVProgram);
            countdown.Stop();
            alert.ShowDialog();
            countdown.Start();

        }
        private void checkBoxCountdown_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCountdown.Checked)
            {
                countdown.Start();
            }
            else
            {
                countdown.Stop();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WatchTimeStatistics wts = new WatchTimeStatistics();
            wts.ShowDialog();
        }

        private void legtöbbetNézettMűfajokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PieStatistics ps = new PieStatistics((Dictionary<TvProgramGenre, int>)TvProgramStatistics.getPieStatistics(Stats.ByGenre));
            ps.ShowDialog();
        }

        private void legtöbbetNézettCsatornákToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PieStatistics ps = new PieStatistics((Dictionary<string, int>)TvProgramStatistics.getPieStatistics(Stats.ByTvChannel));
            ps.ShowDialog();
        }

        private void műsorfoglalásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.PerformClick();
        }
    }
}
