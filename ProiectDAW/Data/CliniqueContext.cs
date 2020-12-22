using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectDAW.Data
{
    public class CliniqueContext : DbContext
    {
        public CliniqueContext() : base("CliniqueConnectionString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<GeneralService> GeneralService { get; set; }
    }
    
}