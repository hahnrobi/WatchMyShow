using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    class TvContext : DbContext
    {
        public TvContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hahnr\source\repos\WatchMyShow\tv.mdf;Integrated Security=True;Connect Timeout=30")
        {
        }
        public DbSet<TvProgram> Programs { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
