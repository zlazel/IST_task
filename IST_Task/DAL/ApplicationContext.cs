using IST_Task.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using School = IST_Task.Models.School;

namespace IST_Task.DAL
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext():base("ApplicationContext") { }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}