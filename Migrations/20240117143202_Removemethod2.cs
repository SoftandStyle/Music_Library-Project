using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    /// <inheritdoc />
    public partial class Removemethod2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistID",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "ReviewID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Album",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_User_ReviewID",
                table: "User",
                column: "ReviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistID",
                table: "Album",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Review_ReviewID",
                table: "User",
                column: "ReviewID",
                principalTable: "Review",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistID",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Review_ReviewID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ReviewID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReviewID",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Album",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistID",
                table: "Album",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
