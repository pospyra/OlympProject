using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructurAnimalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AnimalType");

            migrationBuilder.AlterColumn<long>(
                name: "AnimalId",
                table: "AnimalType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "AnimalType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalType_TypeName_TypeNameId",
                table: "AnimalType",
                column: "TypeNameId",
                principalTable: "TypeName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_TypeName_TypeNameId",
                table: "AnimalType");

            migrationBuilder.DropTable(
                name: "TypeName");

            migrationBuilder.DropIndex(
                name: "IX_AnimalType_TypeNameId",
                table: "AnimalType");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "AnimalType");

            migrationBuilder.DropColumn(
                name: "TypeNameId",
                table: "AnimalType");

            migrationBuilder.AlterColumn<long>(
                name: "AnimalId",
                table: "AnimalType",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AnimalType",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id");
        }
    }
}
