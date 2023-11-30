﻿using backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(job => job.Company)
                .WithMany(company => company.Jobs)
                .HasForeignKey(job => job.CompanyId);

            modelBuilder.Entity<Candidate>()
                .HasOne(candidate => candidate.Job)
                .WithMany(job => job.Candidates)
                .HasForeignKey(candidate => candidate.JobId);
                
        }
    }
}
