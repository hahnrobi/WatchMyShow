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
        public object getStatistics(Stats stats)
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
    }
}
