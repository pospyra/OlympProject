﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    [Migration("20230207133718_changeRelationsLocation_Visited")]
    partial class changeRelationsLocationVisited
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Domain.Animal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ChipperId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ChippingDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ChippingLocationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DeathDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("LifeStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Weihgt")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ChipperId");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("Domain.AnimalType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AnimalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalType", (string)null);
                });

            modelBuilder.Entity("Domain.AnimalVisitedLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AnimalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTimeOfVisitLocationPoint")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("PointId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("PointId");

                    b.ToTable("AnimalVisitedLocation", (string)null);
                });

            modelBuilder.Entity("Domain.LocationPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("LocationPoint", (string)null);
                });

            modelBuilder.Entity("Domain.Animal", b =>
                {
                    b.HasOne("Domain.Account", "Account")
                        .WithMany("Animals")
                        .HasForeignKey("ChipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.AnimalType", b =>
                {
                    b.HasOne("Domain.Animal", "Animal")
                        .WithMany("AnimalTypes")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("Domain.AnimalVisitedLocation", b =>
                {
                    b.HasOne("Domain.Animal", "Animal")
                        .WithMany("VisitedLocation")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.LocationPoint", "LocationPoint")
                        .WithMany("VisitedPoints")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("LocationPoint");
                });

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Domain.Animal", b =>
                {
                    b.Navigation("AnimalTypes");

                    b.Navigation("VisitedLocation");
                });

            modelBuilder.Entity("Domain.LocationPoint", b =>
                {
                    b.Navigation("VisitedPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
