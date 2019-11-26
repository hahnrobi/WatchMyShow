using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchMyShow.DataClasses;
using WatchMyShow.Forms;

namespace WatchMyShow
{
    public enum Stats { ByGenre, ByTvChannel};
    class TvProgramStatistics
    {
        
        public TvProgramStatistics()
        {

        }
        static IEnumerable<TvProgramGenre> GetFlags(TvProgramGenre input)
        {
            return Enum.GetValues(typeof(TvProgramGenre)).Cast<TvProgramGenre>()
               .Where(f => input.HasFlag(f));
        }
        public object getPieStatistics(Stats stats)
        {
            using (TvContext context = new TvContext())
            {
                if (stats == Stats.ByGenre)
                {
                    Dictionary<TvProgramGenre, int> genreStats = new Dictionary<TvProgramGenre, int>();

                    var linq = from p in context.Programs
                               where p.Reserved != null
                               select p.Genre;

                    foreach (var item in linq)
                    {
                        foreach (var flag in GetFlags(item))
                        {
                            if (genreStats.ContainsKey(flag))
                            {
                                genreStats[flag]++;
                            }
                            else
                            {
                                genreStats.Add(flag, 1);
                            }
                        }
                    }
                    return genreStats;
                }
                if (stats == Stats.ByTvChannel)
                {
                    var pl = from p in context.Programs
                             where p.Reserved != null
                            orderby p.TvChannel
                            group p by p.TvChannel into grp
                            select new { key = grp.Key, cnt = grp.Count() };
                    Dictionary<string, int> channelStats = new Dictionary<string, int>();
                    foreach (var item in pl)
                    {
                        channelStats.Add(item.key, item.cnt);
                    }
                    return channelStats;
                }
                return null;
            }
        }
        public Dictionary<DateTime, List<TvProgram>> getWatchedTvPrograms(DateTime fromDate, DateTime toDate)
        {
            fromDate = fromDate.Date;
            toDate = toDate.Date.AddDays(1);
            using (TvContext context = new TvContext())
            {
                List<TvProgram> shows = (from p in context.Programs
                           where p.Reserved != null && p.StartTime >= fromDate && p.EndTime <= toDate
                           select p).ToList();
                Dictionary<DateTime, List<TvProgram>> watchDictionary = new Dictionary<DateTime, List<TvProgram>>();
                while(fromDate < toDate)
                {
                    watchDictionary.Add(fromDate, new List<TvProgram>());
                    fromDate = fromDate.AddDays(1);
                }
                foreach (TvProgram tvProgram in shows)
                {
                        watchDictionary[tvProgram.StartTime.Date].Add(tvProgram);
                }
                return watchDictionary;
            }
        }
        public Dictionary<DateTime, TimeSpan> getWatchTimeStatistics(Dictionary<DateTime, List<TvProgram>> watchedPrograms)
        {
            Dictionary<DateTime, TimeSpan> stat = new Dictionary<DateTime, TimeSpan>();
            foreach (KeyValuePair<DateTime, List<TvProgram>> keyValuePair in watchedPrograms)
            {
                TimeSpan watchTime = TimeSpan.Zero;
                foreach (TvProgram program in keyValuePair.Value)
                {
                    double prevSecs = watchTime.TotalSeconds;
                    watchTime = TimeSpan.FromSeconds(prevSecs + (program.EndTime - program.StartTime).TotalSeconds);
                }
                stat[keyValuePair.Key] = watchTime;
            }
            return stat;
        }
    }
}
