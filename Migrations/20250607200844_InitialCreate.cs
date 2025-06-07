using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolZoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    STATE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "THERMAL_SHELTERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CAPACITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OPENING_HOURS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CITY_ID = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THERMAL_SHELTERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_THERMAL_SHELTERS_CITIES_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_THERMAL_SHELTERS_CITY_ID",
                table: "THERMAL_SHELTERS",
                column: "CITY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "THERMAL_SHELTERS");

            migrationBuilder.DropTable(
                name: "CITIES");
        }
    }
}
