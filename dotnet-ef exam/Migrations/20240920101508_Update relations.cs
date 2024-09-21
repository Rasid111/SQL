using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ef_exam.Migrations
{
    /// <inheritdoc />
    public partial class Updaterelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUser_Communities_CommunityId",
                table: "CommunityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUser_Users_UserId",
                table: "CommunityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunityUser",
                table: "CommunityUser");

            migrationBuilder.DropIndex(
                name: "IX_CommunityUser_CommunityId",
                table: "CommunityUser");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommunityUser");

            migrationBuilder.DropColumn(
                name: "CommunityUserId",
                table: "Communities");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CommunityUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "CommunityUser",
                newName: "CommunitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityUser_UserId",
                table: "CommunityUser",
                newName: "IX_CommunityUser_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunityUser",
                table: "CommunityUser",
                columns: new[] { "CommunitiesId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUser_Communities_CommunitiesId",
                table: "CommunityUser",
                column: "CommunitiesId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUser_Users_UsersId",
                table: "CommunityUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUser_Communities_CommunitiesId",
                table: "CommunityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUser_Users_UsersId",
                table: "CommunityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunityUser",
                table: "CommunityUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "CommunityUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CommunitiesId",
                table: "CommunityUser",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityUser_UsersId",
                table: "CommunityUser",
                newName: "IX_CommunityUser_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CommunityUser",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CommunityUserId",
                table: "Communities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunityUser",
                table: "CommunityUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityUser_CommunityId",
                table: "CommunityUser",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUser_Communities_CommunityId",
                table: "CommunityUser",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUser_Users_UserId",
                table: "CommunityUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
