using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vocabify.API.Migrations
{
    /// <inheritdoc />
    public partial class addrelationbetweensetsandterms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Terms_SetId",
                table: "Terms",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terms_Sets_SetId",
                table: "Terms",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terms_Sets_SetId",
                table: "Terms");

            migrationBuilder.DropIndex(
                name: "IX_Terms_SetId",
                table: "Terms");
        }
    }
}
