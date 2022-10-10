using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akakce.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barcode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Barcode", "Created", "CreatedBy", "Description", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Rate" },
                values: new object[,]
                {
                    { 1L, "PR00001", new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2540), 0L, "PR - 1", false, null, null, "Product 1", 4.8m },
                    { 2L, "PR00002", new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2554), 0L, "PR - 2", false, null, null, "Product 2", 3.2m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1L, "user1@user1.com", "User", "1", "user1*123", "user1" },
                    { 2L, "user2@user2.com", "User", "2", "user2*123", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "ProductId", "Quantity" },
                values: new object[] { 1L, new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2663), 0L, false, null, null, 1L, 5 });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "ProductId", "Quantity" },
                values: new object[] { 2L, new DateTime(2022, 10, 10, 13, 2, 37, 153, DateTimeKind.Local).AddTicks(2664), 0L, false, null, null, 2L, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
