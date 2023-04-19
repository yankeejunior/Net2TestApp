using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightApp.Migrations
{
    /// <inheritdoc />
    public partial class PassengersClassMealTypeAddedToPassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealType",
                schema: "flights",
                table: "Passengers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerClass",
                schema: "flights",
                table: "Passengers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealType",
                schema: "flights",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengerClass",
                schema: "flights",
                table: "Passengers");
        }
    }
}
