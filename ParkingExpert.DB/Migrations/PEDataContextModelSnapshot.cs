﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingExpert.DB;

namespace ParkingExpert.DB.Migrations
{
    [DbContext(typeof(PEDataContext))]
    partial class PEDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingExpert.DB.Entities.ParkingPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ArrivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DepartureAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("Payed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ParkingPlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 6,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 7,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 8,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 9,
                            IsAvailable = true,
                            Payed = false
                        },
                        new
                        {
                            Id = 10,
                            IsAvailable = true,
                            Payed = false
                        });
                });

            modelBuilder.Entity("ParkingExpert.DB.Entities.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PricePerHour = 10m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}