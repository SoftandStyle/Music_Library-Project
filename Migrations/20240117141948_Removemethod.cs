using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    /// <inheritdoc />
    public partial class Removemethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Artist_ArtistID",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_ArtistID",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Artist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Artist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_ArtistID",
                table: "Artist",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Artist_ArtistID",
                table: "Artist",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID");
        }
    }
}
