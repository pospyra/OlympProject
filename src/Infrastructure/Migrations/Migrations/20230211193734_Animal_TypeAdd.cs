using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTypeAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AnimalType_AnimalId",
                table: "AnimalType",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType");

            migrationBuilder.DropIndex(
                name: "IX_AnimalType_AnimalId",
                table: "AnimalType");
        }
    }
}
