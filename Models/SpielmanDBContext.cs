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

        // public virtual DbSet<Calender> Calenders { get; set; } = null!;
        // public virtual DbSet<CalenderTask> CalenderTasks { get; set; } = null!;
        // public virtual DbSet<Garden> Gardens { get; set; } = null!;
        // public virtual DbSet<Plant> Plants { get; set; } = null!;
        // public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=129.82.133.38\\cisweb; Database=SpielmanDB; User ID=angle; Password=jscript; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                .HasColumnName("UserID");


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
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            // modelBuilder.Entity<Garden>(entity =>
            // {
            //     entity.Property(g => g.GardenId)
            //     .HasColumnName("GardenID");

            //     entity.Property(g => g.GardenName)
            //     .HasMaxLength(20);

            //     entity.HasOne(e => e.User)
            //     .WithMany(g => g.Gardens);

            // }
            // );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
