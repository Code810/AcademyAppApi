using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademyApp.Data.Data
{
    public class AcademyContext : DbContext
    {
        public AcademyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Group> groups { get; set; }
        public DbSet<Student> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
