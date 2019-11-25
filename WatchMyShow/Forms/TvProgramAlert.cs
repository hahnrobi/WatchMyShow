using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Forms
{
    public partial class TvProgramAlert : Form
    {
        TvProgram program;
        public TvProgramAlert(TvProgram program)
        {
            InitializeComponent();
            this.program = program;
            timer.Interval = 1000;
            
        }

        private void TvProgramAlert_Load(object sender, EventArgs e)
        {
            this.labelTitle.Text = this.program.Title;
            this.labelCountDown.Text = GetRemainingTime().ToString(@"hh\:mm\:ss");
            this.Text = program.Title + " hamarosan kezdődik: " + GetRemainingTime().ToString(@"hh\:mm\:ss");
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(program.StartTime <= DateTime.Now)
            {
                timer.Stop();
                this.Close();
            }
            this.labelCountDown.Text = GetRemainingTime().ToString(@"hh\:mm\:ss");
            this.Text = program.Title + " hamarosan kezdődik: " + GetRemainingTime().ToString(@"hh\:mm\:ss");

        }
        private TimeSpan GetRemainingTime()
        {
            return (program.StartTime - DateTime.Now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.program.StartTime = DateTime.Now.AddSeconds(5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}
