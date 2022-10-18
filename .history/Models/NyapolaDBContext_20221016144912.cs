﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIv2.models
{
    public partial class NyapolaDBContext : DbContext
    {
        public NyapolaDBContext()
        {
        }

        public NyapolaDBContext(DbContextOptions<NyapolaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calender> Calenders { get; set; } = null!;
        public virtual DbSet<CalenderTask> CalenderTasks { get; set; } = null!;
        public virtual DbSet<Garden> Gardens { get; set; } = null!;
        public virtual DbSet<Plant> Plants { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=BusCISSQL1901.busdom.colostate.edu\\cisweb; Database=NyapolaDB; User ID=ibmblu; Password=first; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calender>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Calender");

                entity.Property(e => e.EventId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EventID");

                entity.Property(e => e.DateTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Date/Time");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GardenId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GardenID");

                entity.HasOne(d => d.Garden)
                    .WithMany(p => p.Calenders)
                    .HasForeignKey(d => d.GardenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calender_Garden");
            });

            modelBuilder.Entity<CalenderTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Calender Tasks");

                entity.Property(e => e.EventId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EventID");

                entity.Property(e => e.TaskId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TaskID");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calender Tasks_Calender");

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calender Tasks_Tasks");
            });

            modelBuilder.Entity<Garden>(entity =>
            {
                entity.ToTable("Garden");

                entity.Property(e => e.GardenId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GardenID");

                entity.Property(e => e.GardenName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Gardens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Garden_User");
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.Property(e => e.PlantId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PlantID");

                entity.Property(e => e.GardenId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GardenID");

                entity.Property(e => e.PlantDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlantName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlantVariety)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Garden)
                    .WithMany(p => p.Plants)
                    .HasForeignKey(d => d.GardenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plants_Garden");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TaskID");

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
