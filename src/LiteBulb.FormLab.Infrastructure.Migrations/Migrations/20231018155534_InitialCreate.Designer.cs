﻿// <auto-generated />
using System;
using LiteBulb.FormLab.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiteBulb.FormLab.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231018155534_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Metadata.FieldMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FormMetadataId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FormMetadataId");

                    b.ToTable("FieldMetadata", (string)null);
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Metadata.FormMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("FormMetadata", (string)null);
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FieldSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FormSubmissionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FormSubmissionId");

                    b.ToTable("FieldSubmission", (string)null);
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FormSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("FormSubmission", (string)null);
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Metadata.FieldMetadata", b =>
                {
                    b.HasOne("LiteBulb.FormLab.Infrastructure.Entities.Metadata.FormMetadata", null)
                        .WithMany("Fields")
                        .HasForeignKey("FormMetadataId");
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FieldSubmission", b =>
                {
                    b.HasOne("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FormSubmission", null)
                        .WithMany("Fields")
                        .HasForeignKey("FormSubmissionId");
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Metadata.FormMetadata", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FormSubmission", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
