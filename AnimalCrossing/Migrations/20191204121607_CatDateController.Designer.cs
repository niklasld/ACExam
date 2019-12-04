﻿// <auto-generated />
using System;
using AnimalCrossing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalCrossing.Migrations
{
    [DbContext(typeof(AnimalCrossingContext))]
    [Migration("20191204121607_CatDateController")]
    partial class CatDateController
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("AnimalCrossing.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CatId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("AnimalCrossing.Models.CatDate", b =>
                {
                    b.Property<int>("CatDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuestCatCatId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HostCatCatId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("CatDateId");

                    b.HasIndex("GuestCatCatId");

                    b.HasIndex("HostCatCatId");

                    b.ToTable("CatDate");
                });

            modelBuilder.Entity("AnimalCrossing.Models.Species", b =>
                {
                    b.Property<int>("SpeciesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SpeciesId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("AnimalCrossing.Models.Cat", b =>
                {
                    b.HasOne("AnimalCrossing.Models.Species", "Species")
                        .WithMany("Cats")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalCrossing.Models.CatDate", b =>
                {
                    b.HasOne("AnimalCrossing.Models.Cat", "GuestCat")
                        .WithMany()
                        .HasForeignKey("GuestCatCatId");

                    b.HasOne("AnimalCrossing.Models.Cat", "HostCat")
                        .WithMany()
                        .HasForeignKey("HostCatCatId");
                });
#pragma warning restore 612, 618
        }
    }
}
