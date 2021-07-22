using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quokka_App.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Quokka_App.Data
{
    public class WebAppContext : IdentityDbContext<WebAppUser>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) 
            : base(options) 
        {  
        }
        public DbSet<StudentReports> GetStudentReports { get; set; }
        public DbSet<WebAppUser> WebAppUsers { get; set; }
        public DbSet<LeaderChecked> GetLeaderChecked { get; set; }
        public DbSet<LeaderAssignedReport> GetAssignedReports { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Emotion> GetEmotions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentReports>().ToTable("StudentReports");
            builder.Entity<LeaderChecked>().ToTable("LeaderChecked");
            builder.Entity<LeaderAssignedReport>().ToTable("LeaderAssignedReport");
            builder.Entity<EmergencyContact>().ToTable("EmergencyContact");
            builder.Entity<Emotion>().ToTable("Emotion");

        }

    }
}
