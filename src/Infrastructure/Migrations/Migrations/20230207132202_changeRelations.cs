using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class changeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVisitedLocation_LocationPoint_LocationPointId",
                table: "AnimalVisitedLocation");

            migrationBuilder.DropIndex(
                name: "IX_AnimalVisitedLocation_LocationPointId",
                table: "AnimalVisitedLocation");

            migrationBuilder.DropColumn(
                name: "LocationPointId",
                table: "AnimalVisitedLocation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LocationPointId",
                table: "AnimalVisitedLocation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalVisitedLocation_LocationPointId",
                table: "AnimalVisitedLocation",
                column: "LocationPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVisitedLocation_LocationPoint_LocationPointId",
                table: "AnimalVisitedLocation",
                column: "LocationPointId",
                principalTable: "LocationPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
