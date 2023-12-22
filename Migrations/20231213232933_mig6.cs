﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace retroomlast.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_People_PersonID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_People_PersonID",
                table: "Comments",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_People_PersonID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_People_PersonID",
                table: "Comments",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID");
        }
    }
}
