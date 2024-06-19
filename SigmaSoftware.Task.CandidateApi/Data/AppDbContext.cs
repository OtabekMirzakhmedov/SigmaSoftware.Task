﻿using Microsoft.EntityFrameworkCore;
using SigmaSoftwareTask.CandidateApi.Models;

namespace SigmaSoftwareTask.CandidateApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
