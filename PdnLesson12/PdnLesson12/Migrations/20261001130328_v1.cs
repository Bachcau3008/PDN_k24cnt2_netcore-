using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdnLesson12.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdnCategory",
                columns: table => new
                {
                    PdnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PdnStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdnCategory", x => x.PdnId);
                });

            migrationBuilder.CreateTable(
                name: "PdnProduct",
                columns: table => new
                {
                    PdnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdnName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PdnImage = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PdnPrice = table.Column<float>(type: "real", nullable: false),
                    PdnSalePrice = table.Column<float>(type: "real", nullable: false),
                    PdnStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    PdnDescription = table.Column<string>(type: "ntext", maxLength: 1000, nullable: false),
                    PdnCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdnProduct", x => x.PdnId);
                    table.ForeignKey(
                        name: "FK_PdnProduct_PdnCategory_PdnCategoryId",
                        column: x => x.PdnCategoryId,
                        principalTable: "PdnCategory",
                        principalColumn: "PdnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdnProduct_PdnCategoryId",
                table: "PdnProduct",
                column: "PdnCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdnProduct");

            migrationBuilder.DropTable(
                name: "PdnCategory");
        }
    }
}
