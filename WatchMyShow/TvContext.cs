using System.Data.Entity;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    internal class TvContext : DbContext
    {
        public TvContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hahnr\source\repos\hahnrobi\WatchMyShow\tv.mdf;Integrated Security=True;Connect Timeout=30")
        {
        }
        public DbSet<TvProgram> Programs { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
