using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Event
{
    class ProgramChangeEventArgs : EventArgs
    {
        public string Channel { get; set; }
        public TvProgram Program { get; set; }
    }
}
