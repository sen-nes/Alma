using AlmaTest.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlmaTest.DAO
{
    public class AlmaContext : DbContext
    {
        public AlmaContext()
            : base("Data")
        { }

        public DbSet<Modules> Modules { get; set; }
        public DbSet<MainTable> MainTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}