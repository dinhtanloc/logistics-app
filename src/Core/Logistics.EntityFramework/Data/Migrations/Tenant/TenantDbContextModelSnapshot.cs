﻿// <auto-generated />
using System;
using Logistics.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Logistics.EntityFramework.Data.Migrations.Tenant
{
    [DbContext(typeof(TenantDbContext))]
    partial class TenantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("employee_roles", b =>
                {
                    b.Property<string>("EmployeesId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("EmployeesId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("employee_roles");
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Load", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssignedDispatcherId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssignedDriverId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssignedTruckId")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("DeliveryCost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DispatchedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Distance")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("PickUpDate")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("RefId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("SourceAddress")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AssignedDispatcherId");

                    b.HasIndex("AssignedDriverId");

                    b.HasIndex("AssignedTruckId");

                    b.HasIndex("RefId")
                        .IsUnique();

                    b.ToTable("loads", (string)null);
                });

            modelBuilder.Entity("Logistics.Domain.Entities.TenantRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Truck", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DriverId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TruckNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.ToTable("trucks", (string)null);
                });

            modelBuilder.Entity("employee_roles", b =>
                {
                    b.HasOne("Logistics.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logistics.Domain.Entities.TenantRole", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Load", b =>
                {
                    b.HasOne("Logistics.Domain.Entities.Employee", "AssignedDispatcher")
                        .WithMany("DispatchedLoads")
                        .HasForeignKey("AssignedDispatcherId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Logistics.Domain.Entities.Employee", "AssignedDriver")
                        .WithMany("DeliveredLoads")
                        .HasForeignKey("AssignedDriverId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Logistics.Domain.Entities.Truck", "AssignedTruck")
                        .WithMany("Loads")
                        .HasForeignKey("AssignedTruckId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("Logistics.Domain.ValueObjects.LoadStatus", "Status", b1 =>
                        {
                            b1.Property<string>("LoadId")
                                .HasColumnType("varchar(255)");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("LoadId");

                            b1.ToTable("loads");

                            b1.WithOwner()
                                .HasForeignKey("LoadId");
                        });

                    b.Navigation("AssignedDispatcher");

                    b.Navigation("AssignedDriver");

                    b.Navigation("AssignedTruck");

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Truck", b =>
                {
                    b.HasOne("Logistics.Domain.Entities.Employee", "Driver")
                        .WithOne()
                        .HasForeignKey("Logistics.Domain.Entities.Truck", "DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Employee", b =>
                {
                    b.Navigation("DeliveredLoads");

                    b.Navigation("DispatchedLoads");
                });

            modelBuilder.Entity("Logistics.Domain.Entities.Truck", b =>
                {
                    b.Navigation("Loads");
                });
#pragma warning restore 612, 618
        }
    }
}
