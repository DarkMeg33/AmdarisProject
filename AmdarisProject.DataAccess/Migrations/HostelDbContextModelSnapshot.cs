﻿// <auto-generated />
using System;
using AmdarisProject.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmdarisProject.DataAccess.Migrations
{
    [DbContext(typeof(HostelDbContext))]
    partial class HostelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AmdarisProject.Domain.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<bool>("HasKitchen")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWashMachine")
                        .HasColumnType("bit");

                    b.Property<int>("HostelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HostelId");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Hostel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HostelNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<bool>("HasShower")
                        .HasColumnType("bit");

                    b.Property<bool>("HasToiler")
                        .HasColumnType("bit");

                    b.Property<int>("NodeNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<int>("BedsideTableCount")
                        .HasColumnType("int");

                    b.Property<bool>("HasCupboard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRepaired")
                        .HasColumnType("bit");

                    b.Property<int?>("NodeId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("TableCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("AmdarisProject.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Floor", b =>
                {
                    b.HasOne("AmdarisProject.Domain.Hostel", "Hostel")
                        .WithMany("Floors")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Node", b =>
                {
                    b.HasOne("AmdarisProject.Domain.Floor", "Floor")
                        .WithMany("Nodes")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Room", b =>
                {
                    b.HasOne("AmdarisProject.Domain.Node", null)
                        .WithMany("Rooms")
                        .HasForeignKey("NodeId");
                });

            modelBuilder.Entity("AmdarisProject.Domain.User", b =>
                {
                    b.HasOne("AmdarisProject.Domain.Room", null)
                        .WithMany("Tenants")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Floor", b =>
                {
                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Hostel", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Node", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("AmdarisProject.Domain.Room", b =>
                {
                    b.Navigation("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
