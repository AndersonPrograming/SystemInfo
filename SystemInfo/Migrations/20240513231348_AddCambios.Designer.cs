﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemInfo.Context;

#nullable disable

namespace SystemInfo.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20240513231348_AddCambios")]
    partial class AddCambios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SystemInfo.Models.ContactType", b =>
                {
                    b.Property<int?>("ContactTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ContactTypeId"));

                    b.Property<string>("TypeContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ContactTypeId");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("SystemInfo.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<string>("DeviceBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("EnergyMeterId")
                        .HasColumnType("int");

                    b.Property<int>("FarmId")
                        .HasColumnType("int");

                    b.Property<string>("GenerationCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("DeviceId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("EnergyMeterId");

                    b.HasIndex("FarmId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("SystemInfo.Models.DeviceType", b =>
                {
                    b.Property<int>("DeviceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceTypeId"));

                    b.Property<string>("TypeDevice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("SystemInfo.Models.EnergyLog", b =>
                {
                    b.Property<int>("EnergyLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnergyLogId"));

                    b.Property<string>("ConsumedEnergyKWH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnergyMeterId")
                        .HasColumnType("int");

                    b.Property<string>("GeneratedEnergyKWH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("EnergyLogId");

                    b.HasIndex("EnergyMeterId");

                    b.ToTable("EnergyLogs");
                });

            modelBuilder.Entity("SystemInfo.Models.EnergyMeter", b =>
                {
                    b.Property<int>("EnergyMeterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnergyMeterId"));

                    b.Property<string>("EnergyMeterBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstalationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("EnergyMeterId");

                    b.ToTable("EnergyMeters");
                });

            modelBuilder.Entity("SystemInfo.Models.Farm", b =>
                {
                    b.Property<int>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmId"));

                    b.Property<string>("FarmArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FarmName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FarmTypeId")
                        .HasColumnType("int");

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("FarmId");

                    b.HasIndex("FarmTypeId");

                    b.HasIndex("FarmerId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("SystemInfo.Models.FarmType", b =>
                {
                    b.Property<int>("FarmTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmTypeId"));

                    b.Property<string>("TypeFarm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("FarmTypeId");

                    b.ToTable("FarmTypes");
                });

            modelBuilder.Entity("SystemInfo.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("FarmerId");

                    b.HasIndex("ContactTypeId");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("SystemInfo.Models.GameModels.Badge", b =>
                {
                    b.Property<int>("BadgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BadgeId"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("NameBadge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BadgeId");

                    b.HasIndex("UserId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("SystemInfo.Models.GameModels.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<string>("EnergyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SystemInfo.Models.GameModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SystemInfo.Models.Device", b =>
                {
                    b.HasOne("SystemInfo.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SystemInfo.Models.EnergyMeter", "EnergyMeter")
                        .WithMany("Devices")
                        .HasForeignKey("EnergyMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SystemInfo.Models.Farm", "Farm")
                        .WithMany("Devices")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceType");

                    b.Navigation("EnergyMeter");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("SystemInfo.Models.EnergyLog", b =>
                {
                    b.HasOne("SystemInfo.Models.EnergyMeter", "EnergyMeter")
                        .WithMany("EnergyLog")
                        .HasForeignKey("EnergyMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnergyMeter");
                });

            modelBuilder.Entity("SystemInfo.Models.Farm", b =>
                {
                    b.HasOne("SystemInfo.Models.FarmType", "FarmType")
                        .WithMany("Farms")
                        .HasForeignKey("FarmTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SystemInfo.Models.Farmer", "Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FarmType");

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("SystemInfo.Models.Farmer", b =>
                {
                    b.HasOne("SystemInfo.Models.ContactType", "ContactType")
                        .WithMany("Farmers")
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");
                });

            modelBuilder.Entity("SystemInfo.Models.GameModels.Badge", b =>
                {
                    b.HasOne("SystemInfo.Models.GameModels.User", "User")
                        .WithMany("Badges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SystemInfo.Models.GameModels.Game", b =>
                {
                    b.HasOne("SystemInfo.Models.GameModels.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SystemInfo.Models.ContactType", b =>
                {
                    b.Navigation("Farmers");
                });

            modelBuilder.Entity("SystemInfo.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("SystemInfo.Models.EnergyMeter", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("EnergyLog");
                });

            modelBuilder.Entity("SystemInfo.Models.Farm", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("SystemInfo.Models.FarmType", b =>
                {
                    b.Navigation("Farms");
                });

            modelBuilder.Entity("SystemInfo.Models.GameModels.User", b =>
                {
                    b.Navigation("Badges");

                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
