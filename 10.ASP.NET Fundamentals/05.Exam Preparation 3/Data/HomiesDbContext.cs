﻿using Homies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<EventParticipant> EventsParticipants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>().HasKey(ep => new { ep.EventId,ep.HelperId });
            modelBuilder
                .Entity<Models.Type>()
                .HasData(new Models.Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Models.Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Models.Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Models.Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}