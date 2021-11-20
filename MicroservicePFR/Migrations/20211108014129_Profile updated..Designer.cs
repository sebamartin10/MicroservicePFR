﻿// <auto-generated />
using MicroservicePFR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroservicePFR.Migrations
{
    [DbContext(typeof(SqlServerDBContext))]
    [Migration("20211108014129_Profile updated.")]
    partial class Profileupdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicroservicePFR.Domain.Models.Favourite", b =>
                {
                    b.Property<string>("articleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("articleID");

                    b.ToTable("Favourite");
                });

            modelBuilder.Entity("MicroservicePFR.Domain.Models.InterestCategory", b =>
                {
                    b.Property<string>("interestCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("amountOfViews")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("interestCategoryId");

                    b.ToTable("InterestCategory");
                });

            modelBuilder.Entity("MicroservicePFR.Domain.Models.UserProfile", b =>
                {
                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
