using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Data.Migrations
{
    public partial class RefatorandoPrecisionVehicleMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufactureres_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<decimal>(
                name: "Vehicle_Price",
                table: "Vehicles",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufactureres_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId",
                principalTable: "Manufactureres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Manufactureres_ManufacturerId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<decimal>(
                name: "Vehicle_Price",
                table: "Vehicles",
                type: "numeric(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Manufactureres_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId",
                principalTable: "Manufactureres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
