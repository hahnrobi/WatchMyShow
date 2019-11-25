using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using WatchMyShow.Forms;
using System.Data.Entity;

namespace WatchMyShow
{
    [Flags]
    enum ProgramDisplay
    {
        OnlyFree = 1,
        OnlyReserved = 2
    }
    class TvProgramManager
    {
        private static string[] genreNames = new string[] { "sorozat", "animációs film", "vígjáték", "dokumentumfilm", "showműsor", "híradó/interjú", "horror", "thriller", "akció", "dráma", "romantikus", "családi", "zene", "reality" };
        private static string[] ageLimitMessages = new string[] {
            "A műsorszám korhatárra való tekintet nélkül megtekinthető.",
            "A műsorszám megtekintése 6 éven aluliak számára nem ajánlott.",
            "A műsorszám megtekintése 12 éven aluliak számára nem ajánlott.",
            "A műsorszám megtekintése 16 éven aluliak számára nem ajánlott.",
            "A műsorszám megtekintése 18 éven aluliak számára nem ajánlott." };
        public static AgeLimit AllAgeLimit()
        {
            AgeLimit limit = AgeLimit.Above12 | AgeLimit.Above16 | AgeLimit.Above18 | AgeLimit.Above6 | AgeLimit.NoLimit;
            return limit;
        }
        public TvProgramManager()
        {
        }
        public Tuple<DateTime, DateTime> GetFirstLastProgramDate()
        {
            Tuple<DateTime, DateTime> result;
            try
            {
                using (TvContext context = new TvContext())
                {
                    var minDate = (from d in context.Programs select d.StartTime).Min();
                    var maxDate = (from d in context.Programs select d.StartTime).Max();
                    result = new Tuple<DateTime, DateTime>(minDate, maxDate);
                }
            }
            catch (Exception)
            {
                result = new Tuple<DateTime, DateTime>(DateTime.Now, DateTime.Now);
            }
            return result;
        }
        ///<summary>
        ///Visszaadja a Tv műsorokat egy List adatszerekezetben.
        ///</summary>
        public List<TvProgram> RetrieveTvPrograms(DateTime time, string channel)
        {
            ProgramDisplay programDisplay = ProgramDisplay.OnlyFree | ProgramDisplay.OnlyReserved;
            AgeLimit limit = AgeLimit.Above12 | AgeLimit.Above16 | AgeLimit.Above18 | AgeLimit.Above6 | AgeLimit.NoLimit;
            return RetrieveTvPrograms(time, channel, programDisplay, limit);
        }
        ///<summary>
        ///Visszaadja a Tv műsorokat egy List adatszerekezetben.
        ///</summary>
        public List<TvProgram> RetrieveTvPrograms(DateTime time, string channel, ProgramDisplay display)
        {
            AgeLimit limit = AgeLimit.Above12 | AgeLimit.Above16 | AgeLimit.Above18 | AgeLimit.Above6 | AgeLimit.NoLimit;
            return RetrieveTvPrograms(time, channel, display, limit);
        }
        ///<summary>
        ///Visszaadja a Tv műsorokat egy List adatszerekezetben.
        ///</summary>
        public List<TvProgram> RetrieveTvPrograms(DateTime time, string channel, AgeLimit ageLimit)
        {
            ProgramDisplay programDisplay = ProgramDisplay.OnlyFree | ProgramDisplay.OnlyReserved;

            return RetrieveTvPrograms(time, channel, programDisplay, ageLimit);
        }
        public List<TvProgram> RetrieveTvPrograms(Tuple<DateTime, DateTime> dateRange, List<string> channels, ProgramDisplay display, AgeLimit ageLimit)
        {
            LinkedList<TvProgram> list = new LinkedList<TvProgram>();
            DateTime startDay = dateRange.Item1.Date;
            DateTime endDay = dateRange.Item2.Date;
            while (startDay.Date <= endDay.Date)
            {
                foreach (string channel in channels)
                {

                    foreach (TvProgram program in RetrieveTvPrograms(startDay, channel, display, ageLimit))
                    {
                        list.AddFirst(program);
                    }
                    startDay.AddDays(1);
                }
                startDay = startDay.AddDays(1);
            }

            return list.ToList();
        }
        public void DeleteReservation(TvProgram program)
        {
            using (TvContext context = new TvContext())
            {
                TvProgram old = context.Programs.First(p => p.ProgramId == program.ProgramId);
                context.Entry(old).State = System.Data.Entity.EntityState.Modified;
                context.Entry(old).Entity.Reserved = null;
                context.Entry(old).Entity.ReservedRoomId = null;
                context.SaveChanges();
            }
        }
        public void AddTvProgram(TvProgram program)
        {
            if(program.Title == "")
            {
                throw new TvProgramCreateEditException("Kötelező címet megadni.", TvProgramCreateEditExceptionDetails.EmptyField);
            }
            if (program.TvChannel == "")
            {
                throw new TvProgramCreateEditException("Kötelező TV csatornát megadni.", TvProgramCreateEditExceptionDetails.EmptyField);
            }
            if (program.Genre == 0)
            {
                throw new TvProgramCreateEditException("Kötelező legalább egy műfajt megadni.", TvProgramCreateEditExceptionDetails.EmptyField);
            }
            if (program.StartTime > program.EndTime)
            {
                throw new TvProgramCreateEditException("Nem kezdődhet később a műsor, mint ahogy vége van.", TvProgramCreateEditExceptionDetails.WrongDateRange);
            }
            using (TvContext context = new TvContext())
            {
                var collision = from p in context.Programs
                                where
                                p.TvChannel == program.TvChannel
                                &&
                                System.Data.Entity.Core.Objects.EntityFunctions.DiffDays(p.StartTime, program.StartTime) == 0
                                &&
                                p.StartTime <= program.StartTime
                                &&
                                p.EndTime > program.StartTime
                                &&
                                p.ProgramId != program.ProgramId
                                select p;
                if (collision.Count() > 0)
                {
                    throw new TvProgramCreateEditException("Ebben az időpontban már van felvéve Tv műsor", TvProgramCreateEditExceptionDetails.Collision);
                }
                if (program.ProgramId != 0)
                {
                    TvProgram old = context.Programs.First(p => p.ProgramId == program.ProgramId);
                    context.Entry(old).State = System.Data.Entity.EntityState.Modified;
                    context.Entry(old).CurrentValues.SetValues(program);
                    Console.WriteLine(context.Entry(old).Entity.Title);
                    context.SaveChanges();
                }
                else
                {
                    context.Programs.Add(program);
                    context.SaveChanges();
                }

            }
        }
        public void DeleteProgram(TvProgram program)
        {
            if (program != null)
            {
                using (TvContext context = new TvContext())
                {
                    TvProgram p = context.Programs.Find(program.ProgramId);
                    context.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                    context.Programs.Remove(p);
                    context.SaveChanges();
                }
            }
        }
        ///<summary>
        ///Visszaadja a Tv műsorokat egy List adatszerekezetben.
        ///</summary>
        public List<TvProgram> RetrieveTvPrograms(DateTime time, string channel, ProgramDisplay display, AgeLimit ageLimit)
        {
            using (TvContext context = new TvContext())
            {

                //Alap lekérés
                var shows = from p in context.Programs
                            where
                            System.Data.Entity.Core.Objects.EntityFunctions.DiffDays(p.StartTime, time) == 0
                            &&
                            (channel == null ? true : p.TvChannel == channel)
                            &&
                            ((p.AgeLimit & ageLimit) != 0)
                            select p;
                //Ha mindkettő be van pipálva akkor ne variáljunk.
                if (!((display & ProgramDisplay.OnlyFree) != 0 && (display & ProgramDisplay.OnlyReserved) != 0))
                {
                    //Szabad időpontok
                    if ((display & ProgramDisplay.OnlyFree) != 0)
                    {
                        shows = from p in shows
                                where p.Reserved == null
                                select p;
                    }
                    //Ffoglalt időpontok
                    if ((display & ProgramDisplay.OnlyReserved) != 0)
                    {
                        shows = from p in shows
                                where p.Reserved != null
                                select p;
                    }
                    //Ha egyik sincs kipipálva
                    if (display == 0)
                    {
                        shows = from p in shows
                                where false
                                select p;
                    }
                }

                //Tv Műsorok visszaadása
                List<TvProgram> programs = new List<TvProgram>();
                foreach (TvProgram item in shows)
                {
                    programs.Add(item);
                }
                return programs;
            }
        }
        //Műfaj enumokhoz tartozó szöveges értékek visszaadása.
        public static string GetGenresAsString(TvProgramGenre genre)
        {
            List<string> genres = new List<string>();
            int i = 0;
            foreach (Enum value in Enum.GetValues(genre.GetType()))
            {
                if (genre.HasFlag(value))
                    genres.Add(genreNames[i]);
                i++;
            }
            return String.Join(",", genres.ToArray());
        }
        public static string[] GetAllGenresAsString()
        {
            return genreNames;
        }
        public static string[] GetAllAgeLimitMessages()
        {
            return ageLimitMessages;
        }
        //Korhatárhoz tartozó hosszabb szövege üzenet.
        public static string GetAgeLimitMessage(AgeLimit limit)
        {
            switch (limit)
            {
                case AgeLimit.NoLimit:
                    return ageLimitMessages[0];
                case AgeLimit.Above6:
                    return ageLimitMessages[1];
                case AgeLimit.Above12:
                    return ageLimitMessages[2];
                case AgeLimit.Above16:
                    return ageLimitMessages[3];
                case AgeLimit.Above18:
                    return ageLimitMessages[4];
                default:
                    return "Ismeretlen korhatár";
            }
        }
        //Tv programok importálása XML fájlból. --> TODO: try catch
        public void ImportTvPrograms(string filepath)
        {
            using (TvContext context = new TvContext())
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<TvProgram>));
                    List<TvProgram> tvPrograms = (List<TvProgram>)ser.Deserialize(sr);
                    foreach (var prgm in tvPrograms)
                    {
                        context.Programs.Add(prgm);
                    }
                    context.SaveChanges();
                }
            }
        }
        //TV program lefoglalása.
        public static void ReserveTvProgram(TvProgram program, Room room)
        {
            using (TvContext context = new TvContext())
            {
                try
                {
                    TvProgram prg = context.Programs.Find(program.ProgramId);
                    Room r = context.Rooms.Find(room.RoomId);
                    prg.Reserved = r;
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nem sikerült a foglalás.\nHiba lépett fel. Frissítsen és próbálja újra.", "Hiba.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //XMLTV fájl parse => TvProgram fájlba. DEV
        [Obsolete("Ne használd. Az XMLTV nem ad elegendő paramértert ahhoz, hogy teljes értékű TvProgram példányt lehessen létrehozni", true)]
        public List<TvProgram> ParseXmlTvFile(string filepath)
        {
            List<TvProgram> programList = new List<TvProgram>();

            XmlDocument xml = new XmlDocument();
            xml.Load(filepath);
            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
            {
                if (node.Name == "programme")
                {
                    TvProgram newProgram = new TvProgram();
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name == "title")
                        {
                            Console.WriteLine(childNode.InnerText);
                        }
                    }

                    programList.Add(newProgram);
                }
            }
            return programList;
        }
        public List<string> GetTvChannels()
        {
            List<string> channels = new List<string>();
            using (TvContext context = new TvContext())
            {
                var getChannels = from program in context.Programs
                                  group program by program.TvChannel into newGroup
                                  orderby newGroup.Key
                                  select newGroup;
                foreach (var ch in getChannels)
                {
                    channels.Add(ch.Key);
                }
            }
            return channels;
        }

        public static TvProgram GetNextProgram(TimeSpan maxRemainingTime)
        {
            using(TvContext context = new TvContext())
            {
                try
                {
                    var nextProgram = (from p in context.Programs
                                       where p.StartTime > DateTime.Now && p.Reserved != null
                                       select p).First();
                    if ((nextProgram.StartTime - DateTime.Now) <= maxRemainingTime)
                    {
                        return (TvProgram)nextProgram;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
