using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    class RandomTvProgramGenerator
    {
        Random r;
        public RandomTvProgramGenerator()
        {
            r = new Random();
        }
        public void BulkGenerate(string[] channels, DateTime from, DateTime to)
        {
            using (TvContext context = new TvContext())
            {
                
                DateTime now = new DateTime(from.Year, from.Month, from.Day);
                while (now.Date != to.Date)
                {
                    foreach (string channel in channels)
                    {
                        List<TvProgram> todayPrograms = GenerateRandomPrograms(channel, now);
                        context.Programs.AddRange(todayPrograms);
                    
                    }
                    
                    now = now.Date.AddDays(1);
                    
                }
                context.SaveChanges();
            }
        }
        public List<TvProgram> GenerateRandomPrograms(string channel, DateTime day)
        {
            List<TvProgram> programs = new List<TvProgram>();
            try
            {
                List<string> names = new List<string>();
                using (StreamReader sr = new StreamReader("tvShowNames.txt",Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        names.Add(sr.ReadLine());
                    }
                    sr.Close();
                }
                DateTime[] times = WatchTimeGenerator(new DateTime(day.Year, day.Month, day.Day, 0, 0, 0));

                while(times[0].Hour != 23 && times[0].Minute != 59 && times[0].Second != 59)
                {
                    TvProgram newProgram = new TvProgram();
                    newProgram.TvChannel = channel;
                    newProgram.Title = names[r.Next(names.Count)];
                    newProgram.AgeLimit = AgeLimitGenerator();
                    newProgram.Genre = GenreGenerator();
                    newProgram.StartTime = times[0];
                    newProgram.EndTime = times[1];
                    times = WatchTimeGenerator(times[1]);
                    programs.Add(newProgram);
                    //Console.WriteLine(newProgram.Title);
                    //Console.WriteLine(newProgram.StartTime);
                    //Console.WriteLine(newProgram.EndTime);
                }

            }
            catch (Exception)
            {

            }
            return programs;
        }
        private AgeLimit AgeLimitGenerator()
        {
            int random = r.Next(0, 101);
            if (random < 20)
            {
                return AgeLimit.NoLimit;
            }
            else
            {
                if (random < 30)
                {
                    return AgeLimit.Above6;
                }
                else
                {
                    if (random < 65)
                    {
                        return AgeLimit.Above12;
                    }
                    else
                    {
                        if (random < 80)
                        {
                            return AgeLimit.Above16;
                        }
                        else
                        {
                            return AgeLimit.Above18;
                        }
                    }
                }

            }
        }
        private DateTime[] WatchTimeGenerator(DateTime start)
        {
            int watchTime = r.Next(20, 141);
            watchTime = (int)Math.Round((double)watchTime / 10, 0) * 10;
            DateTime endTime = start.AddMinutes(watchTime);
            if (endTime.DayOfWeek != start.DayOfWeek)
            {
                endTime = new DateTime(start.Year, start.Month, start.Day, 23, 59, 59);
            }
            return new DateTime[] { start, endTime };
        }
        private TvProgramGenre GenreGenerator()
        {
            TvProgramGenre genre;
            if (r.Next(0, 101) < 70)
            {
                genre = (TvProgramGenre)r.Next(Enum.GetNames(typeof(TvProgramGenre)).Length);
            }
            else
            {
                genre = (TvProgramGenre)r.Next(Enum.GetNames(typeof(TvProgramGenre)).Length);
                genre = genre | (TvProgramGenre)r.Next(Enum.GetNames(typeof(TvProgramGenre)).Length);
            }
            return genre;
        }
    }
}
