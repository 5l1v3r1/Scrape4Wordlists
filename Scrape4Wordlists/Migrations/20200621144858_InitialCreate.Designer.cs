﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scrape4Wordlists.DB;

namespace Scrape4Wordlists.Migrations
{
    [DbContext(typeof(ScraperContext))]
    [Migration("20200621144858_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scrape4Wordlists.Models.ScrapedUri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbsoluteUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Host")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryParams")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scheme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScrapeAttempts")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScrapeDataTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ScrapeFailed")
                        .HasColumnType("bit");

                    b.Property<bool>("Scraped")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("ScrapeUri");
                });
#pragma warning restore 612, 618
        }
    }
}
