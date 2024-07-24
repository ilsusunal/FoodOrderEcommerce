﻿// <auto-generated />
using System;
using FoodOrderApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodOrderApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("FoodOrderApp.Entity.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressName")
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

                    b.HasKey("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.CartProduct", b =>
                {
                    b.Property<int>("CartProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartProductId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProducts");
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

            modelBuilder.Entity("FoodOrderApp.Entity.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderMethod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CardId");

                    b.HasIndex("ShoppingCartId")
                        .IsUnique();

                    b.ToTable("Orders");
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

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.ProductVar", b =>
                {
                    b.Property<int>("ProductVarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DoughSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Materials")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductVarId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVars");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
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

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.UserCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCards");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.CartProduct", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.ShoppingCart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderApp.Entity.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Order", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderApp.Entity.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("FoodOrderApp.Entity.ShoppingCart", "Cart")
                        .WithOne("Order")
                        .HasForeignKey("FoodOrderApp.Entity.Order", "ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Card");

                    b.Navigation("Cart");
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

            modelBuilder.Entity("FoodOrderApp.Entity.ShoppingCart", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.UserAddress", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Address", "Address")
                        .WithMany("UserAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderApp.Entity.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.UserCard", b =>
                {
                    b.HasOne("FoodOrderApp.Entity.Card", "Card")
                        .WithMany("UserCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrderApp.Entity.User", "User")
                        .WithMany("UserCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Address", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Card", b =>
                {
                    b.Navigation("UserCards");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Variations");
                });

            modelBuilder.Entity("FoodOrderApp.Entity.ShoppingCart", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrderApp.Entity.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserAddresses");

                    b.Navigation("UserCards");
                });
#pragma warning restore 612, 618
        }
    }
}
