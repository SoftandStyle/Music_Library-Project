using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    /// <inheritdoc />
    public partial class Method1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DownloadedAlbum_Album_AlbumID1",
                table: "DownloadedAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadedAlbum_User_UserID1",
                table: "DownloadedAlbum");

            migrationBuilder.DropIndex(
                name: "IX_DownloadedAlbum_AlbumID1",
                table: "DownloadedAlbum");

            migrationBuilder.DropIndex(
                name: "IX_DownloadedAlbum_UserID1",
                table: "DownloadedAlbum");

            migrationBuilder.DropColumn(
                name: "AlbumID1",
                table: "DownloadedAlbum");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "DownloadedAlbum");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "DownloadedAlbum",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                table: "DownloadedAlbum",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadedAlbum_AlbumID",
                table: "DownloadedAlbum",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadedAlbum_UserID",
                table: "DownloadedAlbum",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadedAlbum_Album_AlbumID",
                table: "DownloadedAlbum",
                column: "AlbumID",
                principalTable: "Album",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadedAlbum_User_UserID",
                table: "DownloadedAlbum",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DownloadedAlbum_Album_AlbumID",
                table: "DownloadedAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadedAlbum_User_UserID",
                table: "DownloadedAlbum");

            migrationBuilder.DropIndex(
                name: "IX_DownloadedAlbum_AlbumID",
                table: "DownloadedAlbum");

            migrationBuilder.DropIndex(
                name: "IX_DownloadedAlbum_UserID",
                table: "DownloadedAlbum");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "DownloadedAlbum",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AlbumID",
                table: "DownloadedAlbum",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AlbumID1",
                table: "DownloadedAlbum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "DownloadedAlbum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DownloadedAlbum_AlbumID1",
                table: "DownloadedAlbum",
                column: "AlbumID1");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadedAlbum_UserID1",
                table: "DownloadedAlbum",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadedAlbum_Album_AlbumID1",
                table: "DownloadedAlbum",
                column: "AlbumID1",
                principalTable: "Album",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadedAlbum_User_UserID1",
                table: "DownloadedAlbum",
                column: "UserID1",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
