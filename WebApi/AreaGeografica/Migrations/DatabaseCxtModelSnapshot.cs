﻿// <auto-generated />
using System;
using AreaGeografica.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AreaGeografica.Migrations
{
    [DbContext(typeof(DatabaseCxt))]
    partial class DatabaseCxtModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AreaGeografica.Models.Cities", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorStateCities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Countryid")
                        .HasColumnType("int");

                    b.Property<string>("cities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numeroAbitanti")
                        .HasColumnType("int");

                    b.Property<int>("numeroPositivi")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Countryid");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AreaGeografica.Models.Continents", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nameContinent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("AreaGeografica.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Continentsid")
                        .HasColumnType("int");

                    b.Property<string>("nameCountry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Continentsid");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AreaGeografica.Models.Cities", b =>
                {
                    b.HasOne("AreaGeografica.Models.Country", null)
                        .WithMany("cities")
                        .HasForeignKey("Countryid");
                });

            modelBuilder.Entity("AreaGeografica.Models.Country", b =>
                {
                    b.HasOne("AreaGeografica.Models.Continents", null)
                        .WithMany("countries")
                        .HasForeignKey("Continentsid");
                });

            modelBuilder.Entity("AreaGeografica.Models.Continents", b =>
                {
                    b.Navigation("countries");
                });

            modelBuilder.Entity("AreaGeografica.Models.Country", b =>
                {
                    b.Navigation("cities");
                });
#pragma warning restore 612, 618
        }
    }
}