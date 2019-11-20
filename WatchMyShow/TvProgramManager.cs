﻿using System;
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
        public List<TvProgram> RetrieveTvPrograms(DateTime time, CheckedListBox channels, ProgramDisplay display, AgeLimit ageLimit)
        {
            LinkedList<TvProgram> list = new LinkedList<TvProgram>();
            foreach (string channel in channels.CheckedItems)
            {
                foreach (TvProgram program in RetrieveTvPrograms(time, channel, display, ageLimit)) 
                {
                    list.AddFirst(program);
                }
            }
            return list.ToList();
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

    }
}
