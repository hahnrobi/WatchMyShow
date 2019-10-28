using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.Event;

namespace WatchMyShow.Forms
{
    public partial class CalendarPicker : Form
    {
        public CalendarPicker(DateTime date)
        {
            InitializeComponent();
            calendar.SelectionStart = date;
        }
        private DateTime date;
        public event EventHandler<DateEventArgs> DateChanged;
        public DateTime Date
        {
            get { return date; }
            set { calendar.SetDate(value); date = value; }
        }


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.date = calendar.SelectionRange.Start;
            DateChanged?.Invoke(this, new DateEventArgs(calendar.SelectionRange.Start));
        }


    }
}
