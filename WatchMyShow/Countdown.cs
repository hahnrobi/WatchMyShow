using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using WatchMyShow.DataClasses;
using WatchMyShow.Event;

namespace WatchMyShow
{
    class Countdown
    {
        private Timer timer;
        private TvProgram tvProgram;
        public event EventHandler<TvProgramIncomingEventArgs> ProgramIncoming;
        public bool IsRunning
        {
            get { return timer.Enabled; }
        }
        public Countdown()
        {
            timer = new Timer();
            timer.Interval = 2000;
            tvProgram = new TvProgram();
            timer.Elapsed += Tick;
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        private void Tick(object sender, ElapsedEventArgs args)
        {
            TvProgram newProgram= TvProgramManager.GetNextProgram(new TimeSpan(0,15,0));
            if(newProgram != null && newProgram.ProgramId != this.tvProgram.ProgramId)
            {
                this.tvProgram = newProgram;
                ProgramIncoming?.Invoke(this, new TvProgramIncomingEventArgs() { TVProgram = this.tvProgram });
                Console.WriteLine(this.tvProgram.Title);
            }
        }
    }
}
