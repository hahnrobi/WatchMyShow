using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WatchMyShow.DataClasses
{
    /// <summary>
    /// Korhatár ami meghatározza, hogy az adott műsor mely kor felett nézhető.
    /// </summary>
    public enum AgeLimit
    {
        NoLimit,
        Above6,
        Above12,
        Above16,
        Above18
    }

    [Flags]
    /// <summary>
    /// Különféle TV műsor műfajok. Több is kiválasztható.
    /// </summary>
    public enum TvProgramGenre : ushort
    {
        Series =1,
        AnimatedSeries = 2,
        Comedy = 4,
        Documental = 8,
        Show = 16,
        NewsOrInterview = 32,
        Horror = 64,
        Thriller = 128,
        Action = 256,
        Drama = 512,
        Romantic = 1024,
        Family = 2048,
        Music = 4096

    }
    public class TvProgram
    {
        /// <summary>
        /// TV műsor azonosítója az adatbázisban.
        /// </summary>
        [XmlIgnoreAttribute]
        [System.ComponentModel.DataAnnotations.Key]
        public int ProgramId { get; set; }

        /// <summary>
        /// TV műsor azonosítója az adatbázisban.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// TV műsor műfaja. Több is lehet
        /// </summary>
        public TvProgramGenre Genre { get; set; }

        /// <summary>
        /// TV műsort sugárzó csatorna
        /// </summary>
        [XmlElement(ElementName = "Channel")]
        public string TvChannel { get; set; }


        /// <summary>
        /// TV műsor kezdési ideje
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// TV műsor befejezési ideje
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// TV műsor korhatára
        /// </summary>
        public AgeLimit AgeLimit { get; set; }

        public int? ReservedRoomId { get; set; }
        /// <summary>
        /// Foglalás van-e és ha igen melyik szoba.
        /// </summary>
        public virtual Room Reserved { get; set; }

    }

}
