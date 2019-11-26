using System;

namespace WatchMyShow.Event
{
    public class DateEventArgs : EventArgs
    {
        public DateEventArgs(DateTime date)
        {
            Date = date;
        }
        public DateTime Date { get; set; }
    }
}
