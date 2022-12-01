﻿// <auto-generated />
using System;
using BlazorWA.Logging.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWA.Logging.Migrations
{
    [DbContext(typeof(AppLoggingDbContext))]
    partial class AppLoggingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.ActivityLog", b =>
                {
                    b.Property<long>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ActivityId"));

                    b.Property<long?>("AppLogLevelLogLevelId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LogDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LogLevelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlOrModule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.HasIndex("AppLogLevelLogLevelId");

                    b.ToTable("tblActivityLog");
                });

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.ActivityType", b =>
                {
                    b.Property<long>("ActivityTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("ActivityTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityTypeId");

                    b.ToTable("tblActivityTypes");
                });

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.AppLogLevel", b =>
                {
                    b.Property<long>("LogLevelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("LogLevelId");

                    b.ToTable("tblLogLevels");
                });

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.ErrorLog", b =>
                {
                    b.Property<long>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ErrorId"));

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ErrorDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("LogLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlOrModule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ErrorId");

                    b.ToTable("tblErrorLog");
                });

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.ErrorType", b =>
                {
                    b.Property<long>("ErrorTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("ErrorTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ErrorTypeId");

                    b.ToTable("tblErrorTypes");
                });

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.ActivityLog", b =>
                {
                    b.HasOne("BlazorWA.Logging.Database.Models.AppLogLevel", null)
                        .WithMany("ActivityLogs")
                        .HasForeignKey("AppLogLevelLogLevelId");
                });

            modelBuilder.Entity("BlazorWA.Logging.Database.Models.AppLogLevel", b =>
                {
                    b.Navigation("ActivityLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
