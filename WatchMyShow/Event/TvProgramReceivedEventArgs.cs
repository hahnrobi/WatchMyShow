using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Event
{
    class TvProgramReceivedEventArgs : EventArgs
    {
        public List<TvProgram> Programs { get; set; }
        public List<TvProgramControl> ProgramsAsControls { get; set; }
    }
}
