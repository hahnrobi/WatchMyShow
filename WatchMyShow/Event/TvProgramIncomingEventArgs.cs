using System;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Event
{
    internal class TvProgramIncomingEventArgs : EventArgs
    {
        public TvProgram TVProgram { get; set; }
    }
}
