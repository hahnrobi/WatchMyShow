using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WatchMyShow.DataClasses
{
    /// <summary>
    /// Korhatár ami meghatározza, hogy az adott műsor mely kor felett nézhető.
    /// </summary>
    [Flags]
    public enum AgeLimit
    {
        NoLimit = 1,
        Above6 = 2,
        Above12 = 4,
        Above16 = 8,
        Above18 = 16
    }

    [Flags]
    /// <summary>
    /// Különféle TV műsor műfajok. Több is kiválasztható.
    /// </summary>
    public enum TvProgramGenre
    {
        Series = 1,
        Animated = 2,
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
        Music = 4096,
        Reality = 8192

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
        [XmlIgnoreAttribute]
        public int? ReservedRoomId { get; set; }
        /// <summary>
        /// Foglalás van-e és ha igen melyik szoba.
        /// </summary>
        [XmlIgnoreAttribute]
        public virtual Room Reserved { get; set; }

    }

}
