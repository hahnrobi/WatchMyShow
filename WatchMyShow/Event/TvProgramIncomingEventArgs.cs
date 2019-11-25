using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Event
{
    class TvProgramIncomingEventArgs : EventArgs
    {
        public TvProgram TVProgram { get; set; }
    }
}
