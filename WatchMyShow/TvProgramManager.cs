using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;
using System.IO;
using System.Xml.Serialization;

namespace WatchMyShow
{
    class TvProgramManager
    {
        private static string[] genreNames = new string[] { "sorozat", "animációs film", "vígjáték", "dokumentumfilm", "showműsor", "híradó/interjú", "horror", "thriller", "akció", "dráma", "romantikus", "családi", "zene", "reality" };
        private static string[] ageLimitMessages = new string[] {
            "A műsorszám korhatárra való tekintet nélkül megtekinthető.", 
            "A műsorszám megtekintése 6 éven aluliak számára nem ajánlott.", 
            "A műsorszám megtekintése 12 éven aluliak számára nem ajánlott.", 
            "A műsorszám megtekintése 16 éven aluliak számára nem ajánlott.", 
            "A műsorszám megtekintése 18 éven aluliak számára nem ajánlott." };

        public TvProgramManager()
        {
        }


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
    }
}
