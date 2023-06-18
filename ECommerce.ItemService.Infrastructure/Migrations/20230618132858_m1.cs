using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECommerce.ItemService.Infrastructure.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BrandCategories",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCategories", x => new { x.BrandId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BrandCategories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7556), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7566), "BraA", "admin", "BraA" },
                    { 2, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7567), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7568), "BraB", "admin", "BraB" },
                    { 3, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7569), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7569), "BraC", "admin", "BraC" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7571), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7572), "CatA", "admin", "CatA" },
                    { 2, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7573), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7573), "CatB", "admin", "CatB" },
                    { 3, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7574), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7575), "CatC", "admin", "CatC" }
                });

            migrationBuilder.InsertData(
                table: "BrandCategories",
                columns: new[] { "BrandId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedBy", "DateCreated", "DateModified", "Description", "ImageUrl", "ModifiedBy", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7700), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7701), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://alperazurestorage.blob.core.windows.net/mango/14.jpg", "admin", "ProA", 15.0 },
                    { 2, 2, 2, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7710), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7710), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://alperazurestorage.blob.core.windows.net/mango/11.jpg", "admin", "ProB", 13.99 },
                    { 3, 1, 1, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7717), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7717), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://alperazurestorage.blob.core.windows.net/mango/12.jpg", "admin", "ProC", 10.99 },
                    { 4, 3, 3, "admin", new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7723), new DateTime(2023, 6, 18, 16, 28, 58, 671, DateTimeKind.Local).AddTicks(7724), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://alperazurestorage.blob.core.windows.net/mango/13.jpg", "admin", "Pro4", 15.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategories_CategoryId",
                table: "BrandCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
