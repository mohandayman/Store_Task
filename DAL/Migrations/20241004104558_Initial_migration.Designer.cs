﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20241004104558_Initial_migration")]
    partial class Initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DAL.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Acquisition_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("devices");
                });

            modelBuilder.Entity("DAL.Models.DevicePropertyValue", b =>
                {
                    b.Property<int>("Device_Id")
                        .HasColumnType("int");

                    b.Property<int>("Property_Id")
                        .HasColumnType("int");

                    b.Property<string>("Property_Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Device_Id", "Property_Id");

                    b.HasIndex("Property_Id");

                    b.ToTable("devicePropertyValues");
                });

            modelBuilder.Entity("DAL.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("properties");
                });

            modelBuilder.Entity("DAL.Models.Device", b =>
                {
                    b.HasOne("DAL.Models.Category", "CategoryNavigation")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("DAL.Models.DevicePropertyValue", b =>
                {
                    b.HasOne("DAL.Models.Device", "DeviceNavigation")
                        .WithMany("DevicePropertyValues")
                        .HasForeignKey("Device_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Property", "PropertyNavigation")
                        .WithMany("DevicePropertyValues")
                        .HasForeignKey("Property_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceNavigation");

                    b.Navigation("PropertyNavigation");
                });

            modelBuilder.Entity("DAL.Models.Property", b =>
                {
                    b.HasOne("DAL.Models.Category", "CategoryNavigation")
                        .WithMany("Properties")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("DAL.Models.Category", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("DAL.Models.Device", b =>
                {
                    b.Navigation("DevicePropertyValues");
                });

            modelBuilder.Entity("DAL.Models.Property", b =>
                {
                    b.Navigation("DevicePropertyValues");
                });
#pragma warning restore 612, 618
        }
    }
}
