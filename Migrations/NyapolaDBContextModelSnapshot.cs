﻿// <auto-generated />
using System;
using APIv2.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIv2.Migrations
{
    [DbContext(typeof(NyapolaDBContext))]
    partial class NyapolaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIv2.models.Calender", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Date/Time");

                    b.Property<string>("EventName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("GardenId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("GardenID");

                    b.HasKey("EventId");

                    b.HasIndex("GardenId");

                    b.ToTable("Calender", (string)null);
                });

            modelBuilder.Entity("APIv2.models.CalenderTask", b =>
                {
                    b.Property<int>("EventTaskId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("EventTaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventTaskId"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<int>("TaskId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    b.HasKey("EventTaskId");

                    b.HasIndex("EventId");

                    b.HasIndex("TaskId");

                    b.ToTable("Calender Task", (string)null);
                });

            modelBuilder.Entity("APIv2.models.Garden", b =>
                {
                    b.Property<int>("GardenId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("GardenID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GardenId"), 1L, 1);

                    b.Property<string>("GardenName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("GardenId");

                    b.HasIndex("UserId");

                    b.ToTable("Garden", (string)null);
                });

            modelBuilder.Entity("APIv2.models.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("PlantID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<int>("GardenId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("GardenID");

                    b.Property<string>("PlantDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PlantName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PlantVariety")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PlantId");

                    b.HasIndex("GardenId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("APIv2.models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<string>("TaskDescription")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TaskName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("APIv2.models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("CustomerAddress")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerEmail")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("APIv2.models.Calender", b =>
                {
                    b.HasOne("APIv2.models.Garden", "Garden")
                        .WithMany("Calenders")
                        .HasForeignKey("GardenId")
                        .IsRequired()
                        .HasConstraintName("FK_Calender_Garden");

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("APIv2.models.CalenderTask", b =>
                {
                    b.HasOne("APIv2.models.Calender", "Event")
                        .WithMany("CalenderTasks")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("EventID");

                    b.HasOne("APIv2.models.Task", "Task")
                        .WithMany("CalenderTasks")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("TaskID");

                    b.Navigation("Event");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("APIv2.models.Garden", b =>
                {
                    b.HasOne("APIv2.models.User", "User")
                        .WithMany("Gardens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Garden_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIv2.models.Plant", b =>
                {
                    b.HasOne("APIv2.models.Garden", "Garden")
                        .WithMany("Plants")
                        .HasForeignKey("GardenId")
                        .IsRequired()
                        .HasConstraintName("FK_Plants_Garden");

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("APIv2.models.Calender", b =>
                {
                    b.Navigation("CalenderTasks");
                });

            modelBuilder.Entity("APIv2.models.Garden", b =>
                {
                    b.Navigation("Calenders");

                    b.Navigation("Plants");
                });

            modelBuilder.Entity("APIv2.models.Task", b =>
                {
                    b.Navigation("CalenderTasks");
                });

            modelBuilder.Entity("APIv2.models.User", b =>
                {
                    b.Navigation("Gardens");
                });
#pragma warning restore 612, 618
        }
    }
}
