using System.Data.Entity;
using System.Data.SQLite;
using Gorchun.Core.Models;

namespace Gorchun.DataBase
{
    public class MaterialsDbContext : DbContext
    {
        public MaterialsDbContext(string connectionString) : base(new SQLiteConnection(connectionString), true)
        {

        }

        public DbSet<Material> Materials { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Request>().HasMany(r => r.Notifications).WithRequired(n => n.Request);
        //}
    }
}
