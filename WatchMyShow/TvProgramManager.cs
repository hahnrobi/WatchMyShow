using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    class TvProgramManager
    {
        private static string[] genreNames = new string[] { "sorozat", "animációs film", "vígjáték", "dokumentumfilm", "showműsor", "híradó/interjú", "horror", "thriller", "akció", "dráma", "romantikus", "családi", "zene" };
        private static string[] ageLimitMessages = new string[] {
            "A műsorszám korhatárra való tekintet nélkül megtekinthető.", 
            "A műsorszám megtekintése 6 éven aluliak számára nem ajánlott.", 
            "A műsorszám megtekintése 12 éven aluliak számára nem ajánlott.", 
            "A műsorszám megtekintése 16 éven aluliak számára nem ajánlott.", 
            "A műsorszám megtekintése 18 éven aluliak számára nem ajánlott." };
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
        public static string GetAgeLimitMessage(AgeLimit limit)
        {
            return ageLimitMessages[(int)limit];
        }
    }
}
