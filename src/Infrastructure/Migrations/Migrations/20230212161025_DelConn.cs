using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DelConn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_TypeName_TypeNameId",
                table: "AnimalType");

            migrationBuilder.DropTable(
                name: "TypeName");

            migrationBuilder.DropIndex(
                name: "IX_AnimalType_TypeNameId",
                table: "AnimalType");

            migrationBuilder.DropColumn(
                name: "TypeNameId",
                table: "AnimalType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeNameId",
                table: "AnimalType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TypeName",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeName", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalType_TypeNameId",
                table: "AnimalType",
                column: "TypeNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalType_TypeName_TypeNameId",
                table: "AnimalType",
                column: "TypeNameId",
                principalTable: "TypeName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
