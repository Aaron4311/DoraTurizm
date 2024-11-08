using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTourTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Tours",
                newName: "SecondHotel");

            migrationBuilder.RenameColumn(
                name: "ReturningDepartureAndDestinationCity",
                table: "Tours",
                newName: "ReturningDestinationCity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Tours",
                newName: "ReturningDepartureCity");

            migrationBuilder.RenameColumn(
                name: "IntermediatePassageCity",
                table: "Tours",
                newName: "IntermediatePassageSecondCity");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "Tours",
                newName: "FirstHotel");

            migrationBuilder.RenameColumn(
                name: "Hotel",
                table: "Tours",
                newName: "DestinationCity");

            migrationBuilder.RenameColumn(
                name: "DepartureAndDestinationCity",
                table: "Tours",
                newName: "DepartureCity");

            migrationBuilder.AddColumn<string>(
                name: "IntermediatePassageFirstCity",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceForThreeRoom",
                table: "Tours",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceForTwoRoom",
                table: "Tours",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntermediatePassageFirstCity",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "PriceForThreeRoom",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "PriceForTwoRoom",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "SecondHotel",
                table: "Tours",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "ReturningDestinationCity",
                table: "Tours",
                newName: "ReturningDepartureAndDestinationCity");

            migrationBuilder.RenameColumn(
                name: "ReturningDepartureCity",
                table: "Tours",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "IntermediatePassageSecondCity",
                table: "Tours",
                newName: "IntermediatePassageCity");

            migrationBuilder.RenameColumn(
                name: "FirstHotel",
                table: "Tours",
                newName: "ImageUrls");

            migrationBuilder.RenameColumn(
                name: "DestinationCity",
                table: "Tours",
                newName: "Hotel");

            migrationBuilder.RenameColumn(
                name: "DepartureCity",
                table: "Tours",
                newName: "DepartureAndDestinationCity");
        }
    }
}
