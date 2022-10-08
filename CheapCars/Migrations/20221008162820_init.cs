using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheapCars.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellPlaceURLPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialAbilityURLPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialAbilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartSalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndSalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    SellPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_SellPlaces_SellPlaceId",
                        column: x => x.SellPlaceId,
                        principalTable: "SellPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars_Awards",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    AwardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars_Awards", x => new { x.CarId, x.AwardId });
                    table.ForeignKey(
                        name: "FK_Cars_Awards_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Awards_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars_SpecialAbilities",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars_SpecialAbilities", x => new { x.CarId, x.SpecialAbilityId });
                    table.ForeignKey(
                        name: "FK_Cars_SpecialAbilities_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_SpecialAbilities_SpecialAbilities_SpecialAbilityId",
                        column: x => x.SpecialAbilityId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SellPlaceId",
                table: "Cars",
                column: "SellPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Awards_AwardId",
                table: "Cars_Awards",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SpecialAbilities_SpecialAbilityId",
                table: "Cars_SpecialAbilities",
                column: "SpecialAbilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars_Awards");

            migrationBuilder.DropTable(
                name: "Cars_SpecialAbilities");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "SpecialAbilities");

            migrationBuilder.DropTable(
                name: "SellPlaces");
        }
    }
}
