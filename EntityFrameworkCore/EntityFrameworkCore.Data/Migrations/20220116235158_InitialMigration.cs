using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufactureres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer_Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_Model = table.Column<string>(type: "varchar(40)", nullable: false),
                    Vehicle_Information = table.Column<string>(type: "varchar(150)", nullable: false),
                    Vehicle_Price = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufactureres_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufactureres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufactureres_Manufacturer_Name",
                table: "Manufactureres",
                column: "Manufacturer_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Manufactureres");
        }
    }
}
