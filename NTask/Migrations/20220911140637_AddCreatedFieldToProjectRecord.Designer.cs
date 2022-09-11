﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NTask.Data.Contexts;

#nullable disable

namespace NTask.Migrations
{
    [DbContext(typeof(NTaskContext))]
    [Migration("20220911140637_AddCreatedFieldToProjectRecord")]
    partial class AddCreatedFieldToProjectRecord
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("NTask.Data.Models.ActivityRecord", b =>
                {
                    b.Property<Guid>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contents")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TaskRecordTaskId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("ActivityId");

                    b.HasIndex("TaskRecordTaskId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("NTask.Data.Models.ProjectRecord", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NTask.Data.Models.TaskRecord", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectRecordProjectId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("TaskId");

                    b.HasIndex("ProjectRecordProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("NTask.Data.Models.ActivityRecord", b =>
                {
                    b.HasOne("NTask.Data.Models.TaskRecord", "TaskRecord")
                        .WithMany("ActivityRecords")
                        .HasForeignKey("TaskRecordTaskId");

                    b.Navigation("TaskRecord");
                });

            modelBuilder.Entity("NTask.Data.Models.TaskRecord", b =>
                {
                    b.HasOne("NTask.Data.Models.ProjectRecord", "ProjectRecord")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectRecordProjectId");

                    b.Navigation("ProjectRecord");
                });

            modelBuilder.Entity("NTask.Data.Models.ProjectRecord", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("NTask.Data.Models.TaskRecord", b =>
                {
                    b.Navigation("ActivityRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
