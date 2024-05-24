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
    [Migration("20240524045446_InitialCreate")]
    partial class InitialCreate
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
                            Id = new Guid("af46b819-fabf-4dd3-ad7d-15e83aae9088"),
                            Image = "https://images.unsplash.com/photo-1526738549149-8e07eca6c147?q=80&w=1925&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("952c8da5-fdad-47c1-b2db-99038bf9aaed"),
                            Image = "https://plus.unsplash.com/premium_photo-1682435561654-20d84cef00eb?q=80&w=1918&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = new Guid("3cdba833-5f0d-4237-9776-2da2d1753b88"),
                            Image = "https://images.unsplash.com/photo-1556912173-3bb406ef7e77?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Name = "Home Goods"
                        },
                        new
                        {
                            Id = new Guid("080b309c-0931-4add-b380-3b17d6bacdd9"),
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
                            Id = new Guid("4d1dba4e-7ae3-4593-ad64-46edd0eb56b9"),
                            CategoryId = new Guid("af46b819-fabf-4dd3-ad7d-15e83aae9088"),
                            Description = "The Smartphone X10 is packed with cutting-edge features, including a high-resolution camera and a powerful processor, making it perfect for staying connected and productive on the go.",
                            Name = "Smartphone X10",
                            Price = 499.99m
                        },
                        new
                        {
                            Id = new Guid("973ad506-ff27-44f0-a262-adf7f869e6ca"),
                            CategoryId = new Guid("af46b819-fabf-4dd3-ad7d-15e83aae9088"),
                            Description = "The Laptop ProBook 2022 offers superior performance and reliability, featuring a sleek design, long-lasting battery, and advanced security features for your peace of mind.",
                            Name = "Laptop ProBook 2022",
                            Price = 899.99m
                        },
                        new
                        {
                            Id = new Guid("a3a273e4-da8a-4a16-bf7a-726304953994"),
                            CategoryId = new Guid("952c8da5-fdad-47c1-b2db-99038bf9aaed"),
                            Description = "Designed for serious runners, the Running Shoes Elite provide exceptional comfort, support, and durability, allowing you to achieve your personal best with every stride.",
                            Name = "Running Shoes Elite",
                            Price = 129.99m
                        },
                        new
                        {
                            Id = new Guid("74aa5138-6a85-41ce-bcdf-5fcc84b5013c"),
                            CategoryId = new Guid("952c8da5-fdad-47c1-b2db-99038bf9aaed"),
                            Description = "Conquer any trail with confidence in the Hiking Boots Adventure. These rugged boots offer superior traction, waterproof protection, and unmatched durability for your outdoor adventures.",
                            Name = "Hiking Boots Adventure",
                            Price = 149.99m
                        },
                        new
                        {
                            Id = new Guid("c27ac005-b24f-496c-9723-99361d3b4683"),
                            CategoryId = new Guid("3cdba833-5f0d-4237-9776-2da2d1753b88"),
                            Description = "Transform your home into a smart sanctuary with the Smart Home Hub Plus. Control your lights, appliances, and security cameras with ease, and enjoy the convenience of voice commands and automated routines.",
                            Name = "Smart Home Hub Plus",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = new Guid("1d5dd931-5cca-4370-a0ee-2f3c4358b980"),
                            CategoryId = new Guid("3cdba833-5f0d-4237-9776-2da2d1753b88"),
                            Description = "Say goodbye to manual vacuuming with the Robot Vacuum Pro. This intelligent robot cleaner navigates your home effortlessly, removing dirt, dust, and pet hair with precision, leaving your floors spotless.",
                            Name = "Robot Vacuum Pro",
                            Price = 299.99m
                        },
                        new
                        {
                            Id = new Guid("66d428c9-f651-4e64-bd25-02ef38e29d0c"),
                            CategoryId = new Guid("080b309c-0931-4add-b380-3b17d6bacdd9"),
                            Description = "Gather your friends and family for hours of fun with the Board Game Bonanza. Featuring a variety of classic and modern games, this collection is sure to entertain players of all ages.",
                            Name = "Board Game Bonanza",
                            Price = 39.99m
                        },
                        new
                        {
                            Id = new Guid("bd2d9cdd-4a49-4891-9175-3d0d55043451"),
                            CategoryId = new Guid("080b309c-0931-4add-b380-3b17d6bacdd9"),
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
                            Id = new Guid("f60d82d5-c1c8-47fc-9480-cee07ecf1cb8"),
                            ProductId = new Guid("4d1dba4e-7ae3-4593-ad64-46edd0eb56b9"),
                            Url = "https://images.unsplash.com/photo-1598327105666-5b89351aff97?q=80&w=2118&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("1107e309-a5b4-4cd3-bc0c-ef3692adb3b7"),
                            ProductId = new Guid("973ad506-ff27-44f0-a262-adf7f869e6ca"),
                            Url = "https://images.unsplash.com/photo-1559163499-413811fb2344?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("d3340c47-3ec5-45f3-b10c-c6c35043a9de"),
                            ProductId = new Guid("a3a273e4-da8a-4a16-bf7a-726304953994"),
                            Url = "https://images.unsplash.com/photo-1562183241-b937e95585b6?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("491e3ad1-9ede-4e47-a8a7-de28f7d8570a"),
                            ProductId = new Guid("74aa5138-6a85-41ce-bcdf-5fcc84b5013c"),
                            Url = "https://images.unsplash.com/photo-1575987116913-e96e7d490b8a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("0adc2c31-cf08-491a-a539-b124e738c965"),
                            ProductId = new Guid("c27ac005-b24f-496c-9723-99361d3b4683"),
                            Url = "https://images.unsplash.com/photo-1558089687-f282ffcbc126?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("3ad05b24-9952-4b8f-b0f4-3f167c955c96"),
                            ProductId = new Guid("1d5dd931-5cca-4370-a0ee-2f3c4358b980"),
                            Url = "https://images.unsplash.com/photo-1603618090554-f7a5079ffb54?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("aaf89473-77c0-4cb4-ad5c-dd23d201eab7"),
                            ProductId = new Guid("66d428c9-f651-4e64-bd25-02ef38e29d0c"),
                            Url = "https://images.unsplash.com/photo-1610890716171-6b1bb98ffd09?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("4c013041-b763-4a59-983e-cddba06b006c"),
                            ProductId = new Guid("bd2d9cdd-4a49-4891-9175-3d0d55043451"),
                            Url = "https://images.unsplash.com/photo-1587408163744-8482f78bc883?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        },
                        new
                        {
                            Id = new Guid("c14714eb-ca23-49b6-a43c-a22223b8d45e"),
                            ProductId = new Guid("1d5dd931-5cca-4370-a0ee-2f3c4358b980"),
                            Url = "https://images.unsplash.com/photo-1603618090561-412154b4bd1b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D"
                        },
                        new
                        {
                            Id = new Guid("409b3c04-6702-4c3d-936a-0f524d8cb952"),
                            ProductId = new Guid("4d1dba4e-7ae3-4593-ad64-46edd0eb56b9"),
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
                            Id = new Guid("673f692f-8f0a-462e-9624-63c8bcd2ec13"),
                            Avatar = "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg",
                            Email = "admin@mail.com",
                            Name = "Admin",
                            Password = "admin@123",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("752816e8-da77-4c6b-b4c7-0531136d34f3"),
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
                        .WithMany()
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
                        .WithMany()
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
