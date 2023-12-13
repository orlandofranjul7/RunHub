﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RunGroupWebApp.Data;

#nullable disable

namespace RunGroupWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230823192750_Migracion1")]
    partial class Migracion1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RunGroupWebApp.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Addressid")
                        .HasColumnType("int");

                    b.Property<int?>("mileage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Addressid");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ClubCategory")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.Races", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceCategory")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.AppUser", b =>
                {
                    b.HasOne("RunGroupWebApp.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Addressid");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.Club", b =>
                {
                    b.HasOne("RunGroupWebApp.Models.AppUser", "AppUser")
                        .WithMany("Club")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.Races", b =>
                {
                    b.HasOne("RunGroupWebApp.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RunGroupWebApp.Models.AppUser", "AppUser")
                        .WithMany("Races")
                        .HasForeignKey("AppUserId");

                    b.Navigation("Address");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("RunGroupWebApp.Models.AppUser", b =>
                {
                    b.Navigation("Club");

                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
