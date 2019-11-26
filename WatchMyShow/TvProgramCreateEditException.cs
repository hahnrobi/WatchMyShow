using System;
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
    [Serializable]
    internal class TvProgramCreateEditException : Exception
    {
        public string Msg { get; set; }
        public TvProgram Program { get; set; }
        public TvProgramCreateEditExceptionDetails Details { get; set; }
        public TvProgramCreateEditException(string Message, TvProgramCreateEditExceptionDetails details)
        {
            {
                Msg = Message;
                Details = details;
            }
        }
    }
}
