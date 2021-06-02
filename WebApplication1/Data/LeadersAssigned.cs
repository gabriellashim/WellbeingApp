using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quokka_App.Model;

namespace Quokka_App.Data
{
    public class LeadersAssignedContext : DbContext
    {
        public LeadersAssignedContext(DbContextOptions<LeadersAssignedContext> options) : base(options) 
        { 
        }
        public DbSet<Emotion> Emotion { get; set; }
        //public DbSet<LeadersAssigned> LeadersAssigned { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emotion>().ToTable("Emotion");
            //modelBuilder.Entity<LeadersAssigned>().ToTable("LeadersAssigned");
        }
    }
}
