using Microsoft.EntityFrameworkCore.Migrations;

namespace PingVehicleSimulation.Infrastructure.Migrations
{
    public partial class Change_PingStatus_Type_To_Bool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "VehicleStatusTrans",
                type: "bit",
                maxLength: 3,
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "VehicleStatusTrans",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 3);
        }
    }
}
