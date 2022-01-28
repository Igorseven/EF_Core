﻿// <auto-generated />
using System;
using EFCore.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220126004458_NewMigrationV2")]
    partial class NewMigrationV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Manufacturer_Name");

                    b.HasKey("Id")
                        .HasName("Pk_Manufacturer");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufactureres");
                });

            modelBuilder.Entity("EFCore.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Information")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Vehicle_Information");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Vehicle_Model");

                    b.Property<decimal>("Price")
                        .HasPrecision(2)
                        .HasColumnType("numeric(2)")
                        .HasColumnName("Vehicle_Price");

                    b.HasKey("Id")
                        .HasName("Pk_Vehicle");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("EFCore.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("EFCore.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.Navigation("Manufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
