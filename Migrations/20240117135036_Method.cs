using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    /// <inheritdoc />
    public partial class Method : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Review_ReviewID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ReviewID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReviewID",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "DownloadedAlbum",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "DownloadedAlbum");

            migrationBuilder.AddColumn<int>(
                name: "ReviewID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ReviewID",
                table: "User",
                column: "ReviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Review_ReviewID",
                table: "User",
                column: "ReviewID",
                principalTable: "Review",
                principalColumn: "ID");

        }
    }
}
