using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchMyShow.Event
{
    public class DateEventArgs : EventArgs
    {
        public DateEventArgs(DateTime date)
        {
            this.Date = date;
        }
        public DateTime Date { get; set; }
    }
}
