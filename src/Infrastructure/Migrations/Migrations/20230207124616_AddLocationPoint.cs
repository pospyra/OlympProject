using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LocationPointId",
                table: "AnimalVisitedLocation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "LocationPoint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPoint", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVisitedLocation_LocationPoint_LocationPointId",
                table: "AnimalVisitedLocation");

            migrationBuilder.DropTable(
                name: "LocationPoint");

            migrationBuilder.DropIndex(
                name: "IX_AnimalVisitedLocation_LocationPointId",
                table: "AnimalVisitedLocation");

            migrationBuilder.DropColumn(
                name: "LocationPointId",
                table: "AnimalVisitedLocation");
        }
    }
}
