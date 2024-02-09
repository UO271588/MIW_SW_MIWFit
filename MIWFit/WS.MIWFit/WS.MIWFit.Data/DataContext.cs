using Microsoft.EntityFrameworkCore;
using WS.MIWFit.Data.Model;

namespace WS.MIWFit.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data/database.db");
        }
        public DbSet<User> User { get; set; }
        public DbSet<FitStats> FitStats { get; set; }
    }
}