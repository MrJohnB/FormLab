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
    [Migration("20231018223318_AddFormNameAndDescriptionFields")]
    partial class AddFormNameAndDescriptionFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Definitions.FieldDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FormDefinitionId")
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

                    b.HasIndex("FormDefinitionId");

                    b.ToTable("FieldDefinition", (string)null);
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Definitions.FormDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FormDefinition", (string)null);
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FormSubmission", (string)null);
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Definitions.FieldDefinition", b =>
                {
                    b.HasOne("LiteBulb.FormLab.Infrastructure.Entities.Definitions.FormDefinition", null)
                        .WithMany("Fields")
                        .HasForeignKey("FormDefinitionId");
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FieldSubmission", b =>
                {
                    b.HasOne("LiteBulb.FormLab.Infrastructure.Entities.Submissions.FormSubmission", null)
                        .WithMany("Fields")
                        .HasForeignKey("FormSubmissionId");
                });

            modelBuilder.Entity("LiteBulb.FormLab.Infrastructure.Entities.Definitions.FormDefinition", b =>
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
