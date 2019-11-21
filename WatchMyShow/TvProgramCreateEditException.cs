using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    public enum TvProgramCreateEditExceptionDetails
    {
        Collision,
        EmptyField,
        WrongDateRange,
        Unknown
    }
    class TvProgramCreateEditException : Exception
    {
        public string Msg { get; set; }
        public TvProgram Program { get; set; }
        public TvProgramCreateEditExceptionDetails Details { get; set; }
        public TvProgramCreateEditException(string Message, TvProgramCreateEditExceptionDetails details)
        {
            {
                this.Msg = Message;
                this.Details = details;
            }
        }
    }
}
