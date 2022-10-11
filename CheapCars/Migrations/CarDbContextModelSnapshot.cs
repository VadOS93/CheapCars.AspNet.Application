﻿// <auto-generated />
using System;
using CheapCars.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheapCars.Migrations
{
    [DbContext(typeof(CarDbContext))]
    partial class CarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CheapCars.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Awards", (string)null);
                });

            modelBuilder.Entity("CheapCars.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndSalesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SellPlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartSalesDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SellPlaceId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("CheapCars.Models.Joins.Car_Award", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "AwardId");

                    b.HasIndex("AwardId");

                    b.ToTable("Cars_Awards", (string)null);
                });

            modelBuilder.Entity("CheapCars.Models.Joins.Car_SpecialAbility", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialAbilityId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "SpecialAbilityId");

                    b.HasIndex("SpecialAbilityId");

                    b.ToTable("Cars_SpecialAbilities", (string)null);
                });

            modelBuilder.Entity("CheapCars.Models.SellPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellPlaceURLPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SellPlaces", (string)null);
                });

            modelBuilder.Entity("CheapCars.Models.SpecialAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialAbilityURLPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpecialAbilities", (string)null);
                });

            modelBuilder.Entity("CheapCars.Models.Car", b =>
                {
                    b.HasOne("CheapCars.Models.SellPlace", "SellPlace")
                        .WithMany("Cars")
                        .HasForeignKey("SellPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SellPlace");
                });

            modelBuilder.Entity("CheapCars.Models.Joins.Car_Award", b =>
                {
                    b.HasOne("CheapCars.Models.Award", "Award")
                        .WithMany("Cars_Awards")
                        .HasForeignKey("AwardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheapCars.Models.Car", "Car")
                        .WithMany("Cars_Awards")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Award");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CheapCars.Models.Joins.Car_SpecialAbility", b =>
                {
                    b.HasOne("CheapCars.Models.Car", "Car")
                        .WithMany("Cars_SpecialAbilities")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheapCars.Models.SpecialAbility", "SpecialAbility")
                        .WithMany("Cars_SpecialAbilities")
                        .HasForeignKey("SpecialAbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("SpecialAbility");
                });

            modelBuilder.Entity("CheapCars.Models.Award", b =>
                {
                    b.Navigation("Cars_Awards");
                });

            modelBuilder.Entity("CheapCars.Models.Car", b =>
                {
                    b.Navigation("Cars_Awards");

                    b.Navigation("Cars_SpecialAbilities");
                });

            modelBuilder.Entity("CheapCars.Models.SellPlace", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CheapCars.Models.SpecialAbility", b =>
                {
                    b.Navigation("Cars_SpecialAbilities");
                });
#pragma warning restore 612, 618
        }
    }
}
