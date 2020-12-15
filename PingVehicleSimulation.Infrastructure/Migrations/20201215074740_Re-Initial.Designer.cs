﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PingVehicleSimulation.Infrastructure.DataContext;

namespace PingVehicleSimulation.Infrastructure.Migrations
{
    [DbContext(typeof(ALTENStockholmChallengeContext))]
    [Migration("20201215074740_Re-Initial")]
    partial class ReInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("RegNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.VehicleStatusTran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("PingTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleStatusTrans");
                });

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("PingVehicleSimulation.Core.Entities.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Vehicle_Customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.VehicleStatusTran", b =>
                {
                    b.HasOne("PingVehicleSimulation.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("VehicleStatusTrans")
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("FK_VehStatusTrans_Vehicle");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.Customer", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("PingVehicleSimulation.Core.Entities.Vehicle", b =>
                {
                    b.Navigation("VehicleStatusTrans");
                });
#pragma warning restore 612, 618
        }
    }
}
