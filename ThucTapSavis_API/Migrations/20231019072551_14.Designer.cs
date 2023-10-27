﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThucTapSavis_API.Data;

#nullable disable

namespace ThucTapSavis_API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231019072551_14")]
    partial class _14
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChiCuThe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Huyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDTNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Xa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.BillItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductItemsId");

                    b.ToTable("BillItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Cart", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductItemId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductItemId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.ProductItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AvaiableQuantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ColorId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CostPrice")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PurchasePrice")
                        .HasColumnType("int");

                    b.Property<Guid?>("SizeId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.PromotionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PromotionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductItemsId");

                    b.HasIndex("PromotionsId");

                    b.ToTable("PromotionsItem");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChiCuThe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Huyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Xa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Bill", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.User", "Users")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.BillItem", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.Bill", "Bills")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThucTapSavis_Shared.Models.ProductItem", "ProductItems")
                        .WithMany("BillItems")
                        .HasForeignKey("ProductItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bills");

                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Cart", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("ThucTapSavis_Shared.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.CartItem", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.ProductItem", "ProductItems")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThucTapSavis_Shared.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Image", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.ProductItem", "ProductItems")
                        .WithMany("Images")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Product", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.Category", "Categorys")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorys");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.ProductItem", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.Color", "Colors")
                        .WithMany("ProductItem")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThucTapSavis_Shared.Models.Product", "Products")
                        .WithMany("ProductItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThucTapSavis_Shared.Models.Size", "Size")
                        .WithMany("ProductItem")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colors");

                    b.Navigation("Products");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.PromotionItem", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.ProductItem", "ProductItems")
                        .WithMany("PromotionsItems")
                        .HasForeignKey("ProductItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThucTapSavis_Shared.Models.Promotion", "Promotions")
                        .WithMany("PromotionsItem")
                        .HasForeignKey("PromotionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductItems");

                    b.Navigation("Promotions");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.User", b =>
                {
                    b.HasOne("ThucTapSavis_Shared.Models.Role", null)
                        .WithMany("User")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Bill", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Color", b =>
                {
                    b.Navigation("ProductItem");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Product", b =>
                {
                    b.Navigation("ProductItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.ProductItem", b =>
                {
                    b.Navigation("BillItems");

                    b.Navigation("CartItems");

                    b.Navigation("Images");

                    b.Navigation("PromotionsItems");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Promotion", b =>
                {
                    b.Navigation("PromotionsItem");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.Size", b =>
                {
                    b.Navigation("ProductItem");
                });

            modelBuilder.Entity("ThucTapSavis_Shared.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}