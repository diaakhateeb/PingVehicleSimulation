using Microsoft.EntityFrameworkCore.Migrations;

namespace PingVehicleSimulation.Infrastructure.Migrations
{
    public partial class Change_PingStatus_Type_To_BingStatus_Enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "VehicleStatusTrans",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "VehicleStatusTrans",
                type: "bit",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3);
        }
    }
}
