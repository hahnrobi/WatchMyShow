using System;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Event
{
    internal class ProgramChangeEventArgs : EventArgs
    {
        public string Channel { get; set; }
        public TvProgram Program { get; set; }
    }
}
