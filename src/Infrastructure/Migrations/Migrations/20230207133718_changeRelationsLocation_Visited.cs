using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationsLocationVisited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AnimalVisitedLocation_PointId",
                table: "AnimalVisitedLocation",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVisitedLocation_LocationPoint_PointId",
                table: "AnimalVisitedLocation",
                column: "PointId",
                principalTable: "LocationPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVisitedLocation_LocationPoint_PointId",
                table: "AnimalVisitedLocation");

            migrationBuilder.DropIndex(
                name: "IX_AnimalVisitedLocation_PointId",
                table: "AnimalVisitedLocation");
        }
    }
}
