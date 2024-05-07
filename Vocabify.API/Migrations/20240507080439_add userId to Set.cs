using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocabify.API.Migrations
{
    /// <inheritdoc />
    public partial class adduserIdtoSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsCount",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Sets");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_UserId",
                table: "Sets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_AspNetUsers_UserId",
                table: "Sets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_AspNetUsers_UserId",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_UserId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sets");

            migrationBuilder.AddColumn<int>(
                name: "ItemsCount",
                table: "Sets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Sets",
                type: "TEXT",
                nullable: true);
        }
    }
}
