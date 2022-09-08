using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    DailyPrice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.DailyPrice);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "DailyPrice", "BrandId", "DailyPrice1", "ImageUrl1", "ImageUrl" },
                values: new object[] { 1, 1, 15000m, "", "AMG Project One" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "DailyPrice", "BrandId", "DailyPrice1", "ImageUrl1", "ImageUrl" },
                values: new object[] { 2, 1, 1500m, "", "A180" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "DailyPrice", "BrandId", "DailyPrice1", "ImageUrl1", "ImageUrl" },
                values: new object[] { 3, 2, 1600m, "", "A4" });

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
