using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10040092_Nikhil_POE_Part2_PROG6212.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedClaimModelnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeclinedReason",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeclinedReason",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Claims");
        }
    }
}
