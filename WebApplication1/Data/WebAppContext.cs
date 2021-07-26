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
        public DbSet<StudentReports> StudentReportDb { get; set; }
        public DbSet<WebAppUser> WebAppUsers { get; set; }
        public DbSet<LeaderChecked> GetLeaderChecked { get; set; }
        public DbSet<LeaderAssignedReport> GetAssignedReports { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Emotion> EmotionsDb { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentReports>().ToTable("StudentReports");
            builder.Entity<LeaderChecked>().ToTable("LeaderChecked");
            builder.Entity<LeaderAssignedReport>().ToTable("LeaderAssignedReport");
            builder.Entity<EmergencyContact>().ToTable("EmergencyContact");
            builder.Entity<Emotion>().ToTable("Emotion");

            //Association table of LeaderChecked many-to-many relation between StudentReport and WebAppUser
            builder.Entity<LeaderChecked>()
                .HasKey(o => new { o.StudentReportsID, o.WebAppUserID });

            builder.Entity<LeaderChecked>()
                .HasOne(pt => pt.ManyWebAppUser)
                .WithMany(p => p.Userleaderchecked)
                .HasForeignKey(wap => wap.WebAppUserID);

            builder.Entity<LeaderChecked>()
                .HasOne(pt => pt.ManyStudentReports)
                .WithMany(t => t.SRLeaderChecked)
                .HasForeignKey(sr => sr.StudentReportsID);

            //Association table of LeaderAssignedReport many-to-many relation between StudentReport and WebAppUser
            builder.Entity<LeaderAssignedReport>()
                .HasKey(o => new { o.ReportID, o.LeaderID});

            builder.Entity<LeaderAssignedReport>()
                .HasOne(pt => pt.ManyWebAppUser)
                .WithMany(p => p.UserLeaderAssigned)
                .HasForeignKey(wap => wap.LeaderID);

            builder.Entity<LeaderAssignedReport>()
                .HasOne(pt => pt.ManyStudentReports)
                .WithMany(t => t.SRLeaderAssigned)
                .HasForeignKey(sr => sr.ReportID);

            //Association of 1 to many in User and StudentReports table
            builder.Entity<StudentReports>()
                .HasOne(s => s.SRWebAppUser)
                .WithMany(g => g.UserStudentReport)
                .HasForeignKey(s => s.UserID);

            //Association of 1 to many in User FirstName and StudentReports table
            builder.Entity<StudentReports>()
                .HasOne(s => s.SREmotion)
                .WithMany(g => g.EmotionStudentReport)
                .HasForeignKey(s => s.Feeling);
        }
    }
}
