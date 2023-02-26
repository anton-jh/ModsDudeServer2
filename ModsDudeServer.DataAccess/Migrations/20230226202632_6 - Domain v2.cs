using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModsDudeServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _6Domainv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mods_Games_GameId",
                table: "Mods");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Games_GameId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "PluginDependency");

            migrationBuilder.DropTable(
                name: "RepoInvites");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Profiles",
                newName: "RepoId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_GameId",
                table: "Profiles",
                newName: "IX_Profiles_RepoId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Mods",
                newName: "RepoId");

            migrationBuilder.RenameIndex(
                name: "IX_Mods_GameId",
                table: "Mods",
                newName: "IX_Mods_RepoId");

            migrationBuilder.AddColumn<string>(
                name: "AdapterId",
                table: "Repos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipLevel = table.Column<int>(type: "int", nullable: false),
                    Expires = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MultiUse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepoInvite",
                columns: table => new
                {
                    InviteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepoInvite", x => new { x.InviteId, x.Id });
                    table.ForeignKey(
                        name: "FK_RepoInvite_Invites_InviteId",
                        column: x => x.InviteId,
                        principalTable: "Invites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repos_AdapterId",
                table: "Repos",
                column: "AdapterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mods_Repos_RepoId",
                table: "Mods",
                column: "RepoId",
                principalTable: "Repos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Repos_RepoId",
                table: "Profiles",
                column: "RepoId",
                principalTable: "Repos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repos_Plugins_AdapterId",
                table: "Repos",
                column: "AdapterId",
                principalTable: "Plugins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mods_Repos_RepoId",
                table: "Mods");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Repos_RepoId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Repos_Plugins_AdapterId",
                table: "Repos");

            migrationBuilder.DropTable(
                name: "RepoInvite");

            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DropIndex(
                name: "IX_Repos_AdapterId",
                table: "Repos");

            migrationBuilder.DropColumn(
                name: "AdapterId",
                table: "Repos");

            migrationBuilder.RenameColumn(
                name: "RepoId",
                table: "Profiles",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_RepoId",
                table: "Profiles",
                newName: "IX_Profiles_GameId");

            migrationBuilder.RenameColumn(
                name: "RepoId",
                table: "Mods",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Mods_RepoId",
                table: "Mods",
                newName: "IX_Mods_GameId");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Repos_RepoId",
                        column: x => x.RepoId,
                        principalTable: "Repos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepoInvites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Expires = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MembershipLevel = table.Column<int>(type: "int", nullable: false),
                    MultiUse = table.Column<bool>(type: "bit", nullable: false),
                    RepoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepoInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepoInvites_Repos_RepoId",
                        column: x => x.RepoId,
                        principalTable: "Repos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PluginDependency",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PluginId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginDependency", x => new { x.GameId, x.Id });
                    table.ForeignKey(
                        name: "FK_PluginDependency_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_RepoId",
                table: "Games",
                column: "RepoId");

            migrationBuilder.CreateIndex(
                name: "IX_RepoInvites_RepoId",
                table: "RepoInvites",
                column: "RepoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mods_Games_GameId",
                table: "Mods",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Games_GameId",
                table: "Profiles",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
