using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Mappings;
namespace Models
{
   public sealed class DataAccess : DbContext
   {
      public DataAccess(DbContextOptions options) : base(options) { }
      public DbSet<People> People { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new PeopleMapping());
      }
   }
}
