﻿// <auto-generated />
using System;
using CarConfiguratorAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarConfiguratorAPI.Migrations
{
    [DbContext(typeof(CarConfigDbContext))]
    [Migration("20220621194746_remove image column")]
    partial class removeimagecolumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarConfiguratorAPI.Data.Models.EngineModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("CarConfiguratorAPI.Data.Models.OptionalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Optionals");
                });

            modelBuilder.Entity("CarConfiguratorAPI.Data.Models.PaintModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Paints");
                });

            modelBuilder.Entity("CarConfiguratorAPI.Data.Models.ResultModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EngineId")
                        .HasColumnType("int");

                    b.Property<int?>("OptionalId")
                        .HasColumnType("int");

                    b.Property<bool>("OrderComplete")
                        .HasColumnType("bit");

                    b.Property<int?>("PaintId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int?>("WheelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.HasIndex("OptionalId");

                    b.HasIndex("PaintId");

                    b.HasIndex("WheelId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("CarConfiguratorAPI.Data.Models.WheelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Wheels");
                });

            modelBuilder.Entity("CarConfiguratorAPI.Data.Models.ResultModel", b =>
                {
                    b.HasOne("CarConfiguratorAPI.Data.Models.EngineModel", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId");

                    b.HasOne("CarConfiguratorAPI.Data.Models.OptionalModel", "Optional")
                        .WithMany()
                        .HasForeignKey("OptionalId");

                    b.HasOne("CarConfiguratorAPI.Data.Models.PaintModel", "Paint")
                        .WithMany()
                        .HasForeignKey("PaintId");

                    b.HasOne("CarConfiguratorAPI.Data.Models.WheelModel", "Wheel")
                        .WithMany()
                        .HasForeignKey("WheelId");
                });
#pragma warning restore 612, 618
        }
    }
}
