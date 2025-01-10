﻿// <auto-generated /> // Indicates that this file was automatically generated by Entity Framework.
using System; // Provides basic system types like DateTime, etc.
using Microsoft.EntityFrameworkCore; // Provides the Entity Framework Core functionality.
using Microsoft.EntityFrameworkCore.Infrastructure; // Contains types for working with EF Core infrastructure.
using Microsoft.EntityFrameworkCore.Metadata; // Contains types for working with database metadata.
using Microsoft.EntityFrameworkCore.Storage.ValueConversion; // Contains types for value conversions in EF Core.
using SDLoenSystem.Data; // Contains the SDLOENDbContext class and related data models.

#nullable disable // Disables nullable reference types warnings for this file.

namespace SDLoenSystem.Migrations
{
    // The DbContext model snapshot used to track the state of the model.
    // This is used by EF Core to determine what migrations need to be applied.
    [DbContext(typeof(SDLOENDbContext))] // Specifies which DbContext is associated with this snapshot.
    partial class SDLOENDbContextModelSnapshot : ModelSnapshot
    {
        // This method builds the model for the database.
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618 // Disables specific compiler warnings related to obsolete methods.

            // Defines the annotations and configurations for the model.
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0") // Specifies the EF Core version.
                .HasAnnotation("Relational:MaxIdentifierLength", 128); // Sets the max identifier length for relational databases.

            // Configures the use of identity columns for SQL Server (auto-incrementing IDs).
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // Configures the entity for EmployeeInfo.
            modelBuilder.Entity("SDLoenSystem.Models.EmployeeInfo", b =>
            {
                // Configures the primary key for the EmployeeInfo entity.
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd() // Specifies that the ID value will be generated automatically when a new record is added.
                    .HasColumnType("int"); // Specifies the column type in the database (integer).

                // Configures identity column for auto-increment.
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                // Configures the Address property.
                b.Property<string>("Address")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)"); // Specifies the column type in the database (string with no max length).

                // Configures the AuthorizationRequirement property.
                b.Property<string>("AuthorizationRequirement")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)"); // Specifies the column type in the database.

                // Configures the CPRNumber property.
                b.Property<string>("CPRNumber")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the CreationDate property.
                b.Property<DateTime>("CreationDate")
                    .HasColumnType("datetime2"); // Specifies that this is a DateTime field.

                // Configures the Department property.
                b.Property<string>("Department")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the EmailPrivate property.
                b.Property<string>("EmailPrivate")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the EmailWork property.
                b.Property<string>("EmailWork")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the EmploymentDate property.
                b.Property<string>("EmploymentDate")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the EndDate property (nullable).
                b.Property<DateTime?>("EndDate")
                    .HasColumnType("datetime2");

                // Configures the FirstName property.
                b.Property<string>("FirstName")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the Institution property.
                b.Property<string>("Institution")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the JobType property.
                b.Property<string>("JobType")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the LastName property.
                b.Property<string>("LastName")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the LastUpdated property (nullable).
                b.Property<DateTime?>("LastUpdated")
                    .HasColumnType("datetime2");

                // Configures the PhonePrivate property.
                b.Property<string>("PhonePrivate")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the PhoneWork property.
                b.Property<string>("PhoneWork")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the Position property.
                b.Property<string>("Position")
                    .IsRequired() // Marks this property as required.
                    .HasColumnType("nvarchar(max)");

                // Configures the StartDate property (nullable).
                b.Property<DateTime?>("StartDate")
                    .HasColumnType("datetime2");

                // Configures the WorkHours property (non-nullable).
                b.Property<int>("WorkHours")
                    .HasColumnType("int");

                // Configures the primary key constraint for the entity.
                b.HasKey("Id");

                // Specifies the table name for this entity.
                b.ToTable("EmployeeInfos");
            });

#pragma warning restore 612, 618 // Re-enable the suppressed warnings.
        }
    }
}
