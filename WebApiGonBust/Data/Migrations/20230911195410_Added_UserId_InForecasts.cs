using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiGonBust.Migrations
{
    /// <inheritdoc />
    public partial class Added_UserId_InForecasts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Forecasts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_UserId",
                table: "Forecasts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forecasts_AspNetUsers_UserId",
                table: "Forecasts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forecasts_AspNetUsers_UserId",
                table: "Forecasts");

            migrationBuilder.DropIndex(
                name: "IX_Forecasts_UserId",
                table: "Forecasts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Forecasts");
        }
    }
}
