﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoVerhuurLibrary.Models;

#nullable disable

namespace VideoVerhuurLibrary.Migrations
{
    [DbContext(typeof(VideoVerhuurContext))]
    [Migration("20240612083058_EersteMigration")]
    partial class EersteMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("InVoorraad")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotaalVerhuurd")
                        .HasColumnType("int");

                    b.Property<int>("UitVoorraad")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("GenreId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Klant", b =>
                {
                    b.Property<int>("KlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlantId"));

                    b.Property<DateOnly>("DatumLid")
                        .HasColumnType("date");

                    b.Property<string>("Gemeente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HuurAantal")
                        .HasColumnType("int");

                    b.Property<string>("KlantStat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LidGeld")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straat_Nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlantId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Verhuur", b =>
                {
                    b.Property<int>("VerhuurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VerhuurId"));

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("VerhuurDatum")
                        .HasColumnType("date");

                    b.HasKey("VerhuurId");

                    b.HasIndex("FilmId");

                    b.HasIndex("KlantId");

                    b.ToTable("Verhuringen");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Film", b =>
                {
                    b.HasOne("VideoVerhuurLibrary.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Verhuur", b =>
                {
                    b.HasOne("VideoVerhuurLibrary.Models.Film", "Film")
                        .WithMany("Verhuringen")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoVerhuurLibrary.Models.Klant", "Klant")
                        .WithMany("Verhuringen")
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Film", b =>
                {
                    b.Navigation("Verhuringen");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("VideoVerhuurLibrary.Models.Klant", b =>
                {
                    b.Navigation("Verhuringen");
                });
#pragma warning restore 612, 618
        }
    }
}
