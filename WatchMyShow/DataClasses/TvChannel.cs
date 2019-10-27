using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchMyShow.DataClasses
{
    class TvChannel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Alias { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        //public virtual Bitmap Icon { get; private set;}
    }
}
