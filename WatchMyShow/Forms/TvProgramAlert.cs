using System;
using System.Windows.Forms;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Forms
{
    public partial class TvProgramAlert : Form
    {
        private TvProgram program;
        public TvProgramAlert(TvProgram program)
        {
            InitializeComponent();
            this.program = program;
            timer.Interval = 1000;

        }

        private void TvProgramAlert_Load(object sender, EventArgs e)
        {
            labelTitle.Text = program.Title;
            labelCountDown.Text = GetRemainingTime().ToString(@"hh\:mm\:ss");
            Text = program.Title + " hamarosan kezdődik: " + GetRemainingTime().ToString(@"hh\:mm\:ss");
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (program.StartTime <= DateTime.Now)
            {
                timer.Stop();
                Close();
            }
            labelCountDown.Text = GetRemainingTime().ToString(@"hh\:mm\:ss");
            Text = program.Title + " hamarosan kezdődik: " + GetRemainingTime().ToString(@"hh\:mm\:ss");

        }
        private TimeSpan GetRemainingTime()
        {
            return (program.StartTime - DateTime.Now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            program.StartTime = DateTime.Now.AddSeconds(5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }
    }
}
