using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace retroomlast.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_People_PersonID",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_People_PersonID",
                table: "Restaurants",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_People_PersonID",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Restaurants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_People_PersonID",
                table: "Restaurants",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID");
        }
    }
}
