﻿// <auto-generated />
using System;
using EcomShop.Api.src.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EcomShop.Api.Migrations
{
    [DbContext(typeof(EcomShopDbContext))]
    [Migration("20240531093914_seedingdata")]
    partial class seedingdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EcomShop.Core.src.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_categories_name");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"),
                            Image = "https://images.unsplash.com/photo-1526738549149-8e07eca6c147?q=80&w=1925&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"),
                            Image = "https://plus.unsplash.com/premium_photo-1682435561654-20d84cef00eb?q=80&w=1918&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"),
                            Image = "https://images.unsplash.com/photo-1556912173-3bb406ef7e77?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Home Goods"
                        },
                        new
                        {
                            Id = new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"),
                            Image = "https://images.unsplash.com/photo-1500995617113-cf789362a3e1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Toys"
                        });
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_user_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.OrderedLineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_ordered_line_items");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_ordered_line_items_order_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_ordered_line_items_product_id");

                    b.ToTable("ordered_line_items", (string)null);
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("character varying(225)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"),
                            CategoryId = new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"),
                            Description = "The Smartphone X10 is packed with cutting-edge features, including a high-resolution camera and a powerful processor, making it perfect for staying connected and productive on the go.",
                            Name = "Smartphone X10",
                            Price = 499.99m
                        },
                        new
                        {
                            Id = new Guid("122a3f1a-177c-4b08-b457-7481173f8918"),
                            CategoryId = new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"),
                            Description = "The Laptop ProBook 2022 offers superior performance and reliability, featuring a sleek design, long-lasting battery, and advanced security features for your peace of mind.",
                            Name = "Laptop ProBook 2022",
                            Price = 899.99m
                        },
                        new
                        {
                            Id = new Guid("629cfd61-8bac-49fb-9990-c51596e00e0d"),
                            CategoryId = new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"),
                            Description = "Designed for serious runners, the Running Shoes Elite provide exceptional comfort, support, and durability, allowing you to achieve your personal best with every stride.",
                            Name = "Running Shoes Elite",
                            Price = 129.99m
                        },
                        new
                        {
                            Id = new Guid("74c3fa5c-eb83-418c-b472-b8ec09447a71"),
                            CategoryId = new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"),
                            Description = "Conquer any trail with confidence in the Hiking Boots Adventure. These rugged boots offer superior traction, waterproof protection, and unmatched durability for your outdoor adventures.",
                            Name = "Hiking Boots Adventure",
                            Price = 149.99m
                        },
                        new
                        {
                            Id = new Guid("e6a7cc41-6f69-4e40-8108-cad1f1b69351"),
                            CategoryId = new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"),
                            Description = "Transform your home into a smart sanctuary with the Smart Home Hub Plus. Control your lights, appliances, and security cameras with ease, and enjoy the convenience of voice commands and automated routines.",
                            Name = "Smart Home Hub Plus",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"),
                            CategoryId = new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"),
                            Description = "Say goodbye to manual vacuuming with the Robot Vacuum Pro. This intelligent robot cleaner navigates your home effortlessly, removing dirt, dust, and pet hair with precision, leaving your floors spotless.",
                            Name = "Robot Vacuum Pro",
                            Price = 299.99m
                        },
                        new
                        {
                            Id = new Guid("e4d90c4a-999a-4e28-aef6-46151193f6a3"),
                            CategoryId = new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"),
                            Description = "Gather your friends and family for hours of fun with the Board Game Bonanza. Featuring a variety of classic and modern games, this collection is sure to entertain players of all ages.",
                            Name = "Board Game Bonanza",
                            Price = 39.99m
                        },
                        new
                        {
                            Id = new Guid("6e686cbe-152c-448e-8549-01487c00239b"),
                            CategoryId = new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"),
                            Description = "Create unforgettable memories with the Outdoor Playset Deluxe. This premium playset includes a slide, swings, and a climbing wall, providing endless entertainment for kids in the backyard.",
                            Name = "Outdoor Playset Deluxe",
                            Price = 499.99m
                        });
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_product_images");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_product_images_product_id");

                    b.ToTable("product_images", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("49d237c7-5c99-4305-aa74-a5f53f7d18b5"),
                            ProductId = new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"),
                            Url = "https://images.unsplash.com/photo-1598327105666-5b89351aff97?q=80&w=2118&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("f21dd716-86d5-487c-975f-3c5661986abc"),
                            ProductId = new Guid("122a3f1a-177c-4b08-b457-7481173f8918"),
                            Url = "https://images.unsplash.com/photo-1559163499-413811fb2344?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("7f5340c2-72cb-43ad-b442-6ef657baa951"),
                            ProductId = new Guid("629cfd61-8bac-49fb-9990-c51596e00e0d"),
                            Url = "https://images.unsplash.com/photo-1562183241-b937e95585b6?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("ea182bfa-3097-47f9-a27b-603023c2f511"),
                            ProductId = new Guid("74c3fa5c-eb83-418c-b472-b8ec09447a71"),
                            Url = "https://images.unsplash.com/photo-1575987116913-e96e7d490b8a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("9e62a6fd-4dce-40f3-9ce7-a0439a289a10"),
                            ProductId = new Guid("e6a7cc41-6f69-4e40-8108-cad1f1b69351"),
                            Url = "https://images.unsplash.com/photo-1558089687-f282ffcbc126?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("94052d49-a8b1-4bc5-aaf1-d016d604f463"),
                            ProductId = new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"),
                            Url = "https://images.unsplash.com/photo-1603618090554-f7a5079ffb54?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("cf428641-d3bb-4d79-be1c-2248dfe9468e"),
                            ProductId = new Guid("e4d90c4a-999a-4e28-aef6-46151193f6a3"),
                            Url = "https://images.unsplash.com/photo-1610890716171-6b1bb98ffd09?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("fbc3238f-c504-43b1-8c8e-538b2966145f"),
                            ProductId = new Guid("6e686cbe-152c-448e-8549-01487c00239b"),
                            Url = "https://images.unsplash.com/photo-1587408163744-8482f78bc883?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("7842e47f-91e9-48c4-821e-d365dc16708d"),
                            ProductId = new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"),
                            Url = "https://images.unsplash.com/photo-1603618090561-412154b4bd1b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D"
                        },
                        new
                        {
                            Id = new Guid("b04e79f1-5d03-404a-863b-5b5444998a76"),
                            ProductId = new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"),
                            Url = "https://images.unsplash.com/photo-1598327106026-d9521da673d1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D"
                        });
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_user_email");

                    b.ToTable("user", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d967e34-b62c-459a-bd48-bca3e92c0b54"),
                            Avatar = "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg",
                            Email = "thien@123",
                            Name = "thien",
                            Password = "$2a$11$JV/LvGOuu60w1GFJUCWgfemizje/BG1Y/im4mchxo0YG4i1Q1QsGK",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("02613d9c-80f5-4412-8eb6-9bf69f008170"),
                            Avatar = "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg",
                            Email = "john@mail.com",
                            Name = "John",
                            Password = "john@123",
                            Role = 1
                        });
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Order", b =>
                {
                    b.HasOne("EcomShop.Core.src.Entity.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_user_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.OrderedLineItem", b =>
                {
                    b.HasOne("EcomShop.Core.src.Entity.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_ordered_line_items_orders_order_id");

                    b.HasOne("EcomShop.Core.src.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_ordered_line_items_products_product_id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Product", b =>
                {
                    b.HasOne("EcomShop.Core.src.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.ProductImage", b =>
                {
                    b.HasOne("EcomShop.Core.src.Entity.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_images_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.Product", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("EcomShop.Core.src.Entity.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}