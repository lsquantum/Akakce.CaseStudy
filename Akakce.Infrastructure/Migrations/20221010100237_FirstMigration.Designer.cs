﻿// <auto-generated />
using System;
using Akakce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Akakce.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221010100237_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Akakce.Domain.Entities.Basket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("Akakce.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Barcode = "PR00001",
                            Created = new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2540),
                            CreatedBy = 0L,
                            Description = "PR - 1",
                            IsDeleted = false,
                            Name = "Product 1",
                            Rate = 4.8m
                        },
                        new
                        {
                            Id = 2L,
                            Barcode = "PR00002",
                            Created = new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2554),
                            CreatedBy = 0L,
                            Description = "PR - 2",
                            IsDeleted = false,
                            Name = "Product 2",
                            Rate = 3.2m
                        });
                });

            modelBuilder.Entity("Akakce.Domain.Entities.Stock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Stock");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Created = new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2663),
                            CreatedBy = 0L,
                            IsDeleted = false,
                            ProductId = 1L,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2L,
                            Created = new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2664),
                            CreatedBy = 0L,
                            IsDeleted = false,
                            ProductId = 2L,
                            Quantity = 7
                        });
                });

            modelBuilder.Entity("Akakce.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "user1@user1.com",
                            FirstName = "User",
                            LastName = "1",
                            Password = "user1*123",
                            UserName = "user1"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "user2@user2.com",
                            FirstName = "User",
                            LastName = "2",
                            Password = "user2*123",
                            UserName = "user2"
                        });
                });

            modelBuilder.Entity("Akakce.Domain.Entities.Basket", b =>
                {
                    b.HasOne("Akakce.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Akakce.Domain.Entities.Stock", b =>
                {
                    b.HasOne("Akakce.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
