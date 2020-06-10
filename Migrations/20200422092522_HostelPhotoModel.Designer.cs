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
    [Migration("20200422092522_HostelPhotoModel")]
    partial class HostelPhotoModel
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

                    b.Property<string>("HostelAddress");

                    b.Property<string>("HostelDescription");

                    b.Property<string>("HostelLocation");

                    b.Property<string>("HostelName");

                    b.Property<int>("HostelNumberOfRooms");

                    b.Property<string>("HostelSlug");

                    b.Property<string>("HostelType");

                    b.Property<double>("RentPerRoom");

                    b.Property<bool>("VacantRoom");

                    b.Property<int>("userId");

                    b.HasKey("ID");

                    b.HasIndex("userId");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("HosteliteAPI.Models.HostelPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("HostelID");

                    b.Property<bool>("IsMain");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("HostelID");

                    b.ToTable("HostelPhotos");
                });

            modelBuilder.Entity("HosteliteAPI.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("IsMain");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("HosteliteAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<DateTime>("DateJoined");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<bool>("IsLandlord");

                    b.Property<string>("Lastname");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HosteliteAPI.Models.Hostel", b =>
                {
                    b.HasOne("HosteliteAPI.Models.User", "user")
                        .WithMany("hostels")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HosteliteAPI.Models.HostelPhoto", b =>
                {
                    b.HasOne("HosteliteAPI.Models.Hostel", "Hostel")
                        .WithMany("Photos")
                        .HasForeignKey("HostelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HosteliteAPI.Models.Photo", b =>
                {
                    b.HasOne("HosteliteAPI.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
