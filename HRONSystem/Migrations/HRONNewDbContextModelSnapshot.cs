﻿// <auto-generated />
using System; // Provides base class definitions and fundamental types.
using HRONSystem.Data; // Namespace for the HRON system's data layer.
using Microsoft.EntityFrameworkCore; // Provides functionality for Entity Framework Core.
using Microsoft.EntityFrameworkCore.Infrastructure; // Provides the infrastructure for Entity Framework Core.
using Microsoft.EntityFrameworkCore.Metadata; // Contains metadata classes for EF Core.
using Microsoft.EntityFrameworkCore.Storage.ValueConversion; // Provides value conversion utilities.

#nullable disable

namespace HRONSystem.Migrations
{
    // Represents a snapshot of the database schema for the HRONNewDbContext.
    [DbContext(typeof(HRONNewDbContext))]
    partial class HRONNewDbContextModelSnapshot : ModelSnapshot
    {
        // Builds the model for the database schema.
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618 // Suppresses warnings for obsolete APIs.
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0") // Specifies the version of EF Core used.
                .HasAnnotation("Relational:MaxIdentifierLength", 128); // Maximum identifier length for SQL Server.

            // Configures SQL Server-specific identity column behavior.
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // Configures the JobAdvert entity in the database schema.
            modelBuilder.Entity("HRONSystem.Models.JobAdvert", b =>
            {
                // Defines the primary key column.
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd() // Configures the column to auto-generate values.
                    .HasColumnType("int");

                // Configures SQL Server-specific identity column behavior for Id.
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                // Configures the ApplicationDeadline column.
                b.Property<DateTime>("ApplicationDeadline")
                    .HasColumnType("datetime2");

                // Configures the Applications column.
                b.Property<int>("Applications")
                    .HasColumnType("int");

                // Configures the Comments column.
                b.Property<string>("Comments")
                    .IsRequired() // Ensures the column cannot be null.
                    .HasColumnType("nvarchar(max)");

                // Configures the Department column.
                b.Property<string>("Department")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                // Configures the IsArchived column.
                b.Property<bool>("IsArchived")
                    .HasColumnType("bit");

                // Configures the JobTitle column with a maximum length of 255 characters.
                b.Property<string>("JobTitle")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                // Configures the Media column.
                b.Property<string>("Media")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                // Configures the PublishingDate column.
                b.Property<DateTime>("PublishingDate")
                    .HasColumnType("datetime2");

                // Configures the Responsible column.
                b.Property<string>("Responsible")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                // Configures the Status column.
                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                // Configures the Views column.
                b.Property<int>("Views")
                    .HasColumnType("int");

                // Configures the primary key for the table.
                b.HasKey("Id");

                // Maps the entity to the JobAdverts table.
                b.ToTable("JobAdverts");
            });
#pragma warning restore 612, 618 // Restores warnings for obsolete APIs.
        }
    }
}
