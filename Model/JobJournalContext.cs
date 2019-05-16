using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace JobJournal
{
    public partial class JobJournalContext : DbContext
    {
        public JobJournalContext()
        {
        }

        public JobJournalContext(DbContextOptions<JobJournalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlCe(ConfigurationManager.ConnectionStrings["JobJournalDatabase"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.ApplicationSource)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
