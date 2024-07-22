﻿// <auto-generated />
using System;
using FoodOrderApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodOrderApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240722210319_MakeCardNoLong")]
    partial class MakeCardNoLong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("AddressUser", b =>
                {
                    b.Property<int>("AddressListAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressListAddressId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("AddressUser");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressName")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressType")
                        .HasColumnType("TEXT");

                    b.Property<int>("AptNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .HasColumnType("TEXT");

                    b.Property<string>("Neighbourhood")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CardNo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpireMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpireYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameOnCard")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MaterialName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductVarId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaterialId");

                    b.HasIndex("ProductVarId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("TEXT");

                    b.HasKey("PaymentId");

                    b.HasIndex("CardId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.ProductVar", b =>
                {
                    b.Property<int>("ProductVarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductVarId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVars");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AddressUser", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressListAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderApp.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Card", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Material", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.ProductVar", null)
                        .WithMany("Materials")
                        .HasForeignKey("ProductVarId");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Order", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.OrderProduct", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderApp.Entity.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Payment", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("FoodOrderApp.Entity.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("FoodOrderApp.Entity.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Product", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.ProductVar", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Product", "Product")
                        .WithMany("Variations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Order", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Variations");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.ProductVar", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.User", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
