﻿// <auto-generated />
using BeverlyHillsZoo.Web.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeverlyHillsZoo.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231018093607_AddTblAnimals")]
    partial class AddTblAnimals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeverlyHillsZoo.Web.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("animals");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BeverlyHillsZoo.Web.Models.HabitatAir", b =>
                {
                    b.HasBaseType("BeverlyHillsZoo.Web.Models.Animal");

                    b.Property<int>("MaxAltitude")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("BeverlyHillsZoo.Web.Models.HabitatLand", b =>
                {
                    b.HasBaseType("BeverlyHillsZoo.Web.Models.Animal");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("BeverlyHillsZoo.Web.Models.HabitatWater", b =>
                {
                    b.HasBaseType("BeverlyHillsZoo.Web.Models.Animal");

                    b.Property<int>("DivingDepth")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(3);
                });
#pragma warning restore 612, 618
        }
    }
}
