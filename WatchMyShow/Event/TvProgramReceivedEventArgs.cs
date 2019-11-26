using System;
using System.Collections.Generic;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Event
{
    internal class TvProgramReceivedEventArgs : EventArgs
    {
        public List<TvProgram> Programs { get; set; }
        public List<TvProgramControl> ProgramsAsControls { get; set; }
    }
}
