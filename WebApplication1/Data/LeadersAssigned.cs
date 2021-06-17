﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quokka_App.Model;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Quokka_App.Data
{
    public class LeadersAssignedContext : DbContext
    {
        public LeadersAssignedContext(DbContextOptions<LeadersAssignedContext> options) : base(options) 
        { 
        }
        public DbSet<Emotion> Emotion { get; set; }
        //public DbSet<LeadersAssigned> LeadersAssigned { get; set; }
        public DbSet<UserClass> UserClass { get; set; }
        public DbSet<AspNewUsers> AspNetUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emotion>().ToTable("Emotion");
            modelBuilder.Entity<LeadersAssigned>().ToTable("LeadersAssigned");
        }
        //public DbSet<LeadersAssigned> LeadersAssigned { get; set; }

        public DbSet<Quokka_App.Model.LeadersAssigned> LeadersAssigned { get; set; }
    }
}
