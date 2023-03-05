﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TonerTracker.DAL;

#nullable disable

namespace TonerTracker.DAL.Migrations
{
    [DbContext(typeof(TonerTrackerContext))]
    [Migration("20230207045136_PerPaperRate to Machine entity")]
    partial class PerPaperRatetoMachineentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TonerTracker.Domain.Entity.BillGenerate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("MonthlyBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaperCountID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PaperCountID");

                    b.ToTable("BillGenerates");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.Branch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.Machine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BWSerialNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BlackSerialNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("ColourType")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("CyanSerialNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MachineModelNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MachineSerialNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MagentaSerialNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<decimal?>("PerPaperRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("YellowSerialNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("BranchID");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.PaperCount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("CurrentCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MachineID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousCount")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPaper")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MachineID");

                    b.ToTable("PaperCounts");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.TonerDelivery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeliveryBW")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryBlack")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryCyan")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryMagenta")
                        .HasColumnType("int");

                    b.Property<int?>("DeliveryYellow")
                        .HasColumnType("int");

                    b.Property<int?>("InHouseBW")
                        .HasColumnType("int");

                    b.Property<int?>("InHouseBlack")
                        .HasColumnType("int");

                    b.Property<int?>("InHouseCyan")
                        .HasColumnType("int");

                    b.Property<int?>("InHouseMagenta")
                        .HasColumnType("int");

                    b.Property<int?>("InHouseYellow")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MachineBW")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MachineBlack")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MachineCyan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MachineID")
                        .HasColumnType("int");

                    b.Property<decimal?>("MachineMagenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MachineYellow")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<decimal?>("StockBW")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StockBlack")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StockCyan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StockMagenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StockYellow")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("MachineID");

                    b.ToTable("TonerDeliveries");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.BillGenerate", b =>
                {
                    b.HasOne("TonerTracker.Domain.Entity.PaperCount", "PaperCount")
                        .WithMany()
                        .HasForeignKey("PaperCountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaperCount");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.Branch", b =>
                {
                    b.HasOne("TonerTracker.Domain.Entity.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.Machine", b =>
                {
                    b.HasOne("TonerTracker.Domain.Entity.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.PaperCount", b =>
                {
                    b.HasOne("TonerTracker.Domain.Entity.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("TonerTracker.Domain.Entity.TonerDelivery", b =>
                {
                    b.HasOne("TonerTracker.Domain.Entity.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });
#pragma warning restore 612, 618
        }
    }
}
