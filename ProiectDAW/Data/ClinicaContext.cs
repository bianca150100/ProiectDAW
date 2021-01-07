using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectDAW.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext() : base("ClinicaConnectionString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Medic> Medici { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<GeneralService> GeneralService { get; set; }


        public DbSet<Appointment> Appointments { get; set; }
    }
    
}