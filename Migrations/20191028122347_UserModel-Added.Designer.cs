﻿// <auto-generated />
using System;
using HosteliteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HosteliteAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191028122347_UserModel-Added")]
    partial class UserModelAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HosteliteAPI.Models.Hostel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedHostel");

                    b.Property<string>("HostelAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("HostelDescription")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("HostelLocation")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("HostelName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("HostelNumberOfRooms");

                    b.Property<string>("HostelSlug")
                        .HasMaxLength(200);

                    b.Property<string>("HostelType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("RentPerRoom");

                    b.Property<bool>("VacantRoom");

                    b.HasKey("ID");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("HosteliteAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}