using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcomShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("05843984-19d1-4bf8-aadf-ec2a6fce6915"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("06c5d2e6-4225-4bce-a1b4-d555c26a7f3d"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("13e17a05-e642-4728-8146-8c3d1c5133b0"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("2293661f-ea6d-455c-a350-c7f2e04873af"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("6252aa5e-d4aa-46e9-809c-844ec4205e41"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("64e0bd8c-d27e-4218-ae10-dd7bfa65dca0"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("a1b5b944-9fa0-41b5-8f44-c6b01f01be2c"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("f34004ba-fa7c-4ec0-8538-2d91b9d381b0"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("f3e7ee52-b8ab-4cd9-9fa6-ea7471d707be"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("f62cc9b3-2d01-47f1-a80b-7f6668d7f0c8"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("c25a7708-c759-424c-84ee-5f7f9fd844a7"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("ff78662b-d35d-46e4-91b4-3c012e9262d2"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0cc02199-0634-41e9-a6cc-24a730c2d2af"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("1d738996-2f13-43e8-bdce-2f76b3b01f23"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("42d737f2-544e-4154-9028-a1ea79ae609f"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("5fa0e495-1c6b-472c-920c-a6b92790bbb0"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("63ed73f9-ce8f-4ac2-9e8c-8119613ded4e"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("8aa330b2-ced2-4725-9baf-83622536e3e4"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("bc6d7884-7ee0-46ac-b877-98e0febd8b5c"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e994ca61-a37e-49a8-85a1-29b43d2f427a"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("183c939a-cd7b-4ffb-83ea-e91f9085e004"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("33400c02-411a-4fd7-b9e6-a9c3ec963f9d"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("553950a3-9a67-46a0-9888-c7845543ea38"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("5554197c-61bd-4f40-b0da-b6fac201913a"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "image", "name" },
                values: new object[,]
                {
                    { new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"), "https://images.unsplash.com/photo-1500995617113-cf789362a3e1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Toys" },
                    { new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"), "https://plus.unsplash.com/premium_photo-1682435561654-20d84cef00eb?q=80&w=1918&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Shoes" },
                    { new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"), "https://images.unsplash.com/photo-1526738549149-8e07eca6c147?q=80&w=1925&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Electronics" },
                    { new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"), "https://images.unsplash.com/photo-1556912173-3bb406ef7e77?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Home Goods" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "avatar", "email", "name", "password", "role" },
                values: new object[,]
                {
                    { new Guid("02613d9c-80f5-4412-8eb6-9bf69f008170"), "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg", "john@mail.com", "John", "john@123", 1 },
                    { new Guid("9d967e34-b62c-459a-bd48-bca3e92c0b54"), "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg", "thien@123", "thien", "$2a$11$JV/LvGOuu60w1GFJUCWgfemizje/BG1Y/im4mchxo0YG4i1Q1QsGK", 0 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "description", "name", "price" },
                values: new object[,]
                {
                    { new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"), new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"), "Say goodbye to manual vacuuming with the Robot Vacuum Pro. This intelligent robot cleaner navigates your home effortlessly, removing dirt, dust, and pet hair with precision, leaving your floors spotless.", "Robot Vacuum Pro", 299.99m },
                    { new Guid("122a3f1a-177c-4b08-b457-7481173f8918"), new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"), "The Laptop ProBook 2022 offers superior performance and reliability, featuring a sleek design, long-lasting battery, and advanced security features for your peace of mind.", "Laptop ProBook 2022", 899.99m },
                    { new Guid("629cfd61-8bac-49fb-9990-c51596e00e0d"), new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"), "Designed for serious runners, the Running Shoes Elite provide exceptional comfort, support, and durability, allowing you to achieve your personal best with every stride.", "Running Shoes Elite", 129.99m },
                    { new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"), new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"), "The Smartphone X10 is packed with cutting-edge features, including a high-resolution camera and a powerful processor, making it perfect for staying connected and productive on the go.", "Smartphone X10", 499.99m },
                    { new Guid("6e686cbe-152c-448e-8549-01487c00239b"), new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"), "Create unforgettable memories with the Outdoor Playset Deluxe. This premium playset includes a slide, swings, and a climbing wall, providing endless entertainment for kids in the backyard.", "Outdoor Playset Deluxe", 499.99m },
                    { new Guid("74c3fa5c-eb83-418c-b472-b8ec09447a71"), new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"), "Conquer any trail with confidence in the Hiking Boots Adventure. These rugged boots offer superior traction, waterproof protection, and unmatched durability for your outdoor adventures.", "Hiking Boots Adventure", 149.99m },
                    { new Guid("e4d90c4a-999a-4e28-aef6-46151193f6a3"), new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"), "Gather your friends and family for hours of fun with the Board Game Bonanza. Featuring a variety of classic and modern games, this collection is sure to entertain players of all ages.", "Board Game Bonanza", 39.99m },
                    { new Guid("e6a7cc41-6f69-4e40-8108-cad1f1b69351"), new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"), "Transform your home into a smart sanctuary with the Smart Home Hub Plus. Control your lights, appliances, and security cameras with ease, and enjoy the convenience of voice commands and automated routines.", "Smart Home Hub Plus", 199.99m }
                });

            migrationBuilder.InsertData(
                table: "product_images",
                columns: new[] { "id", "product_id", "url" },
                values: new object[,]
                {
                    { new Guid("49d237c7-5c99-4305-aa74-a5f53f7d18b5"), new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"), "https://images.unsplash.com/photo-1598327105666-5b89351aff97?q=80&w=2118&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("7842e47f-91e9-48c4-821e-d365dc16708d"), new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"), "https://images.unsplash.com/photo-1603618090561-412154b4bd1b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D" },
                    { new Guid("7f5340c2-72cb-43ad-b442-6ef657baa951"), new Guid("629cfd61-8bac-49fb-9990-c51596e00e0d"), "https://images.unsplash.com/photo-1562183241-b937e95585b6?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("94052d49-a8b1-4bc5-aaf1-d016d604f463"), new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"), "https://images.unsplash.com/photo-1603618090554-f7a5079ffb54?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("9e62a6fd-4dce-40f3-9ce7-a0439a289a10"), new Guid("e6a7cc41-6f69-4e40-8108-cad1f1b69351"), "https://images.unsplash.com/photo-1558089687-f282ffcbc126?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("b04e79f1-5d03-404a-863b-5b5444998a76"), new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"), "https://images.unsplash.com/photo-1598327106026-d9521da673d1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D" },
                    { new Guid("cf428641-d3bb-4d79-be1c-2248dfe9468e"), new Guid("e4d90c4a-999a-4e28-aef6-46151193f6a3"), "https://images.unsplash.com/photo-1610890716171-6b1bb98ffd09?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("ea182bfa-3097-47f9-a27b-603023c2f511"), new Guid("74c3fa5c-eb83-418c-b472-b8ec09447a71"), "https://images.unsplash.com/photo-1575987116913-e96e7d490b8a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("f21dd716-86d5-487c-975f-3c5661986abc"), new Guid("122a3f1a-177c-4b08-b457-7481173f8918"), "https://images.unsplash.com/photo-1559163499-413811fb2344?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("fbc3238f-c504-43b1-8c8e-538b2966145f"), new Guid("6e686cbe-152c-448e-8549-01487c00239b"), "https://images.unsplash.com/photo-1587408163744-8482f78bc883?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("49d237c7-5c99-4305-aa74-a5f53f7d18b5"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("7842e47f-91e9-48c4-821e-d365dc16708d"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("7f5340c2-72cb-43ad-b442-6ef657baa951"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("94052d49-a8b1-4bc5-aaf1-d016d604f463"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("9e62a6fd-4dce-40f3-9ce7-a0439a289a10"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("b04e79f1-5d03-404a-863b-5b5444998a76"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("cf428641-d3bb-4d79-be1c-2248dfe9468e"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("ea182bfa-3097-47f9-a27b-603023c2f511"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("f21dd716-86d5-487c-975f-3c5661986abc"));

            migrationBuilder.DeleteData(
                table: "product_images",
                keyColumn: "id",
                keyValue: new Guid("fbc3238f-c504-43b1-8c8e-538b2966145f"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("02613d9c-80f5-4412-8eb6-9bf69f008170"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("9d967e34-b62c-459a-bd48-bca3e92c0b54"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("0bdaf9e6-9c8d-45a8-aa20-a29a59712cdb"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("122a3f1a-177c-4b08-b457-7481173f8918"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("629cfd61-8bac-49fb-9990-c51596e00e0d"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("673eb849-f9e7-46f7-94fd-a91cda48a75d"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("6e686cbe-152c-448e-8549-01487c00239b"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("74c3fa5c-eb83-418c-b472-b8ec09447a71"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e4d90c4a-999a-4e28-aef6-46151193f6a3"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: new Guid("e6a7cc41-6f69-4e40-8108-cad1f1b69351"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("04c89057-1c61-4d4a-baa0-aa4e303a9b21"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("77c70291-d615-4e74-b9af-7edeecbc7656"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("897f52d2-1f2b-4f9c-94c8-db35f9c6589e"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("f573fc45-91f0-4473-86a9-b4ae352999f2"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "image", "name" },
                values: new object[,]
                {
                    { new Guid("183c939a-cd7b-4ffb-83ea-e91f9085e004"), "https://images.unsplash.com/photo-1526738549149-8e07eca6c147?q=80&w=1925&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Electronics" },
                    { new Guid("33400c02-411a-4fd7-b9e6-a9c3ec963f9d"), "https://images.unsplash.com/photo-1500995617113-cf789362a3e1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Toys" },
                    { new Guid("553950a3-9a67-46a0-9888-c7845543ea38"), "https://plus.unsplash.com/premium_photo-1682435561654-20d84cef00eb?q=80&w=1918&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Shoes" },
                    { new Guid("5554197c-61bd-4f40-b0da-b6fac201913a"), "https://images.unsplash.com/photo-1556912173-3bb406ef7e77?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Home Goods" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "avatar", "email", "name", "password", "role" },
                values: new object[,]
                {
                    { new Guid("c25a7708-c759-424c-84ee-5f7f9fd844a7"), "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg", "admin@mail.com", "Admin", "admin@123", 0 },
                    { new Guid("ff78662b-d35d-46e4-91b4-3c012e9262d2"), "https://static.vecteezy.com/system/resources/thumbnails/006/487/917/small_2x/man-avatar-icon-free-vector.jpg", "john@mail.com", "John", "john@123", 1 }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category_id", "description", "name", "price" },
                values: new object[,]
                {
                    { new Guid("0cc02199-0634-41e9-a6cc-24a730c2d2af"), new Guid("33400c02-411a-4fd7-b9e6-a9c3ec963f9d"), "Create unforgettable memories with the Outdoor Playset Deluxe. This premium playset includes a slide, swings, and a climbing wall, providing endless entertainment for kids in the backyard.", "Outdoor Playset Deluxe", 499.99m },
                    { new Guid("1d738996-2f13-43e8-bdce-2f76b3b01f23"), new Guid("183c939a-cd7b-4ffb-83ea-e91f9085e004"), "The Smartphone X10 is packed with cutting-edge features, including a high-resolution camera and a powerful processor, making it perfect for staying connected and productive on the go.", "Smartphone X10", 499.99m },
                    { new Guid("42d737f2-544e-4154-9028-a1ea79ae609f"), new Guid("33400c02-411a-4fd7-b9e6-a9c3ec963f9d"), "Gather your friends and family for hours of fun with the Board Game Bonanza. Featuring a variety of classic and modern games, this collection is sure to entertain players of all ages.", "Board Game Bonanza", 39.99m },
                    { new Guid("5fa0e495-1c6b-472c-920c-a6b92790bbb0"), new Guid("183c939a-cd7b-4ffb-83ea-e91f9085e004"), "The Laptop ProBook 2022 offers superior performance and reliability, featuring a sleek design, long-lasting battery, and advanced security features for your peace of mind.", "Laptop ProBook 2022", 899.99m },
                    { new Guid("63ed73f9-ce8f-4ac2-9e8c-8119613ded4e"), new Guid("553950a3-9a67-46a0-9888-c7845543ea38"), "Conquer any trail with confidence in the Hiking Boots Adventure. These rugged boots offer superior traction, waterproof protection, and unmatched durability for your outdoor adventures.", "Hiking Boots Adventure", 149.99m },
                    { new Guid("8aa330b2-ced2-4725-9baf-83622536e3e4"), new Guid("5554197c-61bd-4f40-b0da-b6fac201913a"), "Transform your home into a smart sanctuary with the Smart Home Hub Plus. Control your lights, appliances, and security cameras with ease, and enjoy the convenience of voice commands and automated routines.", "Smart Home Hub Plus", 199.99m },
                    { new Guid("bc6d7884-7ee0-46ac-b877-98e0febd8b5c"), new Guid("5554197c-61bd-4f40-b0da-b6fac201913a"), "Say goodbye to manual vacuuming with the Robot Vacuum Pro. This intelligent robot cleaner navigates your home effortlessly, removing dirt, dust, and pet hair with precision, leaving your floors spotless.", "Robot Vacuum Pro", 299.99m },
                    { new Guid("e994ca61-a37e-49a8-85a1-29b43d2f427a"), new Guid("553950a3-9a67-46a0-9888-c7845543ea38"), "Designed for serious runners, the Running Shoes Elite provide exceptional comfort, support, and durability, allowing you to achieve your personal best with every stride.", "Running Shoes Elite", 129.99m }
                });

            migrationBuilder.InsertData(
                table: "product_images",
                columns: new[] { "id", "product_id", "url" },
                values: new object[,]
                {
                    { new Guid("05843984-19d1-4bf8-aadf-ec2a6fce6915"), new Guid("0cc02199-0634-41e9-a6cc-24a730c2d2af"), "https://images.unsplash.com/photo-1587408163744-8482f78bc883?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("06c5d2e6-4225-4bce-a1b4-d555c26a7f3d"), new Guid("42d737f2-544e-4154-9028-a1ea79ae609f"), "https://images.unsplash.com/photo-1610890716171-6b1bb98ffd09?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("13e17a05-e642-4728-8146-8c3d1c5133b0"), new Guid("8aa330b2-ced2-4725-9baf-83622536e3e4"), "https://images.unsplash.com/photo-1558089687-f282ffcbc126?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("2293661f-ea6d-455c-a350-c7f2e04873af"), new Guid("e994ca61-a37e-49a8-85a1-29b43d2f427a"), "https://images.unsplash.com/photo-1562183241-b937e95585b6?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("6252aa5e-d4aa-46e9-809c-844ec4205e41"), new Guid("5fa0e495-1c6b-472c-920c-a6b92790bbb0"), "https://images.unsplash.com/photo-1559163499-413811fb2344?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("64e0bd8c-d27e-4218-ae10-dd7bfa65dca0"), new Guid("63ed73f9-ce8f-4ac2-9e8c-8119613ded4e"), "https://images.unsplash.com/photo-1575987116913-e96e7d490b8a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("a1b5b944-9fa0-41b5-8f44-c6b01f01be2c"), new Guid("1d738996-2f13-43e8-bdce-2f76b3b01f23"), "https://images.unsplash.com/photo-1598327105666-5b89351aff97?q=80&w=2118&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("f34004ba-fa7c-4ec0-8538-2d91b9d381b0"), new Guid("bc6d7884-7ee0-46ac-b877-98e0febd8b5c"), "https://images.unsplash.com/photo-1603618090554-f7a5079ffb54?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("f3e7ee52-b8ab-4cd9-9fa6-ea7471d707be"), new Guid("1d738996-2f13-43e8-bdce-2f76b3b01f23"), "https://images.unsplash.com/photo-1598327106026-d9521da673d1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D" },
                    { new Guid("f62cc9b3-2d01-47f1-a80b-7f6668d7f0c8"), new Guid("bc6d7884-7ee0-46ac-b877-98e0febd8b5c"), "https://images.unsplash.com/photo-1603618090561-412154b4bd1b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDF8fHxlbnwwfHx8fHw%3D" }
                });
        }
    }
}
