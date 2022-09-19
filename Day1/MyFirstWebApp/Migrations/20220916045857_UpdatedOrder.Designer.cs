﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFirstWebApp.Models;

#nullable disable

namespace MyFirstWebApp.Migrations
{
    [DbContext(typeof(PizzaStroreContext))]
    [Migration("20220916045857_UpdatedOrder")]
    partial class UpdatedOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyFirstWebApp.Models.Order", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderNumber"), 1L, 1);

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderNumber");

                    b.HasIndex("Username");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.OrderPizzas", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumebr")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "OrderNumebr");

                    b.HasIndex("OrderNumebr");

                    b.ToTable("OrderPizzas");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumber");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Name = "Pan Pizza",
                            Pic = "images/Pic1.jpg",
                            Price = 120.4f
                        },
                        new
                        {
                            Id = 102,
                            Name = "Veg Extravenzza",
                            Pic = "images/Pic2.jpg",
                            Price = 450f
                        });
                });

            modelBuilder.Entity("MyFirstWebApp.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.Order", b =>
                {
                    b.HasOne("MyFirstWebApp.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.OrderPizzas", b =>
                {
                    b.HasOne("MyFirstWebApp.Models.Order", "Order")
                        .WithMany("OrdersPizzas")
                        .HasForeignKey("OrderNumebr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyFirstWebApp.Models.Pizza", "Pizza")
                        .WithMany("Orders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.Pizza", b =>
                {
                    b.HasOne("MyFirstWebApp.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderNumber");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.Order", b =>
                {
                    b.Navigation("OrdersPizzas");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.Pizza", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MyFirstWebApp.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
