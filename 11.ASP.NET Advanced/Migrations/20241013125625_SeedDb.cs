using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KickShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Sizes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "The Size Of The Product");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Image For The Category");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("22bbee1d-be8f-4a72-95ea-cbdaf99e92d5"), "USA", "Everlast" },
                    { new Guid("2e212bce-01d2-452c-8216-7b8781b8cb41"), "Germany", "Adidas" },
                    { new Guid("46ab2bd4-daa1-4b88-9e92-23124b1baabd"), "France", "Venum" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("2fd11087-2f31-48ab-9f2b-e3b0e14fd94e"), "/images/apparel-category.jpg", "Apparel" },
                    { new Guid("362a3ecf-159c-4a45-bfa8-d724e16405f3"), "/images/gloves-category.jpg", "Gloves" },
                    { new Guid("987405c8-9ab8-4bd6-b93b-a8ea4af528c8"), "/images/protective-gear-category.jpg", "Protective Gear" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Sizes", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("4ff6255a-5073-43fa-b5f0-44aea081d633"), new Guid("46ab2bd4-daa1-4b88-9e92-23124b1baabd"), new Guid("987405c8-9ab8-4bd6-b93b-a8ea4af528c8"), "Essential mouth guard for protecting your teeth.", "/images/mouth-guard.jpg", "Mouth Guard", 12.99m, "[0,1,2,3]", 6 },
                    { new Guid("6072e9bf-fe05-4331-948d-7e68412acceb"), new Guid("22bbee1d-be8f-4a72-95ea-cbdaf99e92d5"), new Guid("362a3ecf-159c-4a45-bfa8-d724e16405f3"), "High-quality kickboxing gloves for training and competition.", "/images/gloves.jpg", "Kickboxing Gloves", 49.99m, "[0,1,2,3]", 5 },
                    { new Guid("a9c3c6d4-e8c9-40e5-bcae-f89cbc1e287e"), new Guid("22bbee1d-be8f-4a72-95ea-cbdaf99e92d5"), new Guid("2fd11087-2f31-48ab-9f2b-e3b0e14fd94e"), "Comfortable shorts designed for kickboxing training.", "/images/shorts.jpg", "Kickboxing Shorts", 29.99m, "[0,1,2,3]", 4 },
                    { new Guid("b270a5eb-afcb-4bf4-8340-383191b2aa48"), new Guid("46ab2bd4-daa1-4b88-9e92-23124b1baabd"), new Guid("362a3ecf-159c-4a45-bfa8-d724e16405f3"), "Durable shin guards for protection during sparring.", "/images/shin-guards.jpg", "Shin Guards", 35.99m, "[0,1,2,3]", 6 },
                    { new Guid("f4782bfd-737d-45be-8b2b-b643552352a2"), new Guid("2e212bce-01d2-452c-8216-7b8781b8cb41"), new Guid("987405c8-9ab8-4bd6-b93b-a8ea4af528c8"), "Protective headgear for safety during training.", "/images/headgear.jpg", "Headgear", 59.99m, "[0,1,2,3]", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4ff6255a-5073-43fa-b5f0-44aea081d633"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6072e9bf-fe05-4331-948d-7e68412acceb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a9c3c6d4-e8c9-40e5-bcae-f89cbc1e287e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b270a5eb-afcb-4bf4-8340-383191b2aa48"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f4782bfd-737d-45be-8b2b-b643552352a2"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("22bbee1d-be8f-4a72-95ea-cbdaf99e92d5"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("2e212bce-01d2-452c-8216-7b8781b8cb41"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("46ab2bd4-daa1-4b88-9e92-23124b1baabd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2fd11087-2f31-48ab-9f2b-e3b0e14fd94e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("362a3ecf-159c-4a45-bfa8-d724e16405f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("987405c8-9ab8-4bd6-b93b-a8ea4af528c8"));

            migrationBuilder.DropColumn(
                name: "Sizes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The Size Of The Product");
        }
    }
}
