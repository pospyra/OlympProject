﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AnimalTypeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType");

            migrationBuilder.AlterColumn<long>(
                name: "AnimalId",
                table: "AnimalType",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalType_Animal_AnimalId",
                table: "AnimalType",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
