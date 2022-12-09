using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIv2.models;

namespace APIv2.models
{
    public partial class SpielmanDBContext : DbContext
    {
        public SpielmanDBContext()
        {
        }

        public SpielmanDBContext(DbContextOptions<SpielmanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        // public virtual DbSet<CalenderTask> CalenderTasks { get; set; } = null!;
        public virtual DbSet<Garden> Gardens { get; set; } = null!;
        public virtual DbSet<Plant> Plants { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Sensor> Sensors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=129.82.133.38\\cisweb; Database=SpielmanDB; User ID=angle; Password=jscript; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Garden>(entity =>
            {


                entity.Property(g => g.GardenName)
                .HasMaxLength(20);


            }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<APIv2.models.Plant> Plant { get; set; }

        public DbSet<APIv2.models.Job> Task { get; set; }

        public DbSet<APIv2.models.Event> Event { get; set; }
        public DbSet<APIv2.models.Sensor> Sensor { get; set; }
        public DbSet<APIv2.models.Garden> Garden { get; set; }
    }
}
