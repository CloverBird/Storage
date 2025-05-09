﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Storage.DataBase.DbContexts;

#nullable disable

namespace Storage.DataBase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250504170952_ChangeModelsForReport")]
    partial class ChangeModelsForReport
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Storage.Core.Models.ProductsBatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ProducingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("ProductPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductsBatches", (string)null);
                });

            modelBuilder.Entity("Storage.Core.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Reports", (string)null);
                });

            modelBuilder.Entity("Storage.Core.Models.ReportItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductsBatchId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ReportId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsBatchId");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportItems", (string)null);
                });

            modelBuilder.Entity("Storage.Core.Models.ReportItem", b =>
                {
                    b.HasOne("Storage.Core.Models.ProductsBatch", "ProductsBatch")
                        .WithMany()
                        .HasForeignKey("ProductsBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Storage.Core.Models.Report", "Report")
                        .WithMany("ReportItems")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProductsBatch");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Storage.Core.Models.Report", b =>
                {
                    b.Navigation("ReportItems");
                });
#pragma warning restore 612, 618
        }
    }
}
