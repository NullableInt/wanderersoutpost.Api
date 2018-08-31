using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dndChar.Database.Migrations
{
    public partial class AddedCharactersAndPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "CharacterStats",
                columns: table => new
                {
                    CharacterStatsId = table.Column<Guid>(nullable: false),
                    ProficiencyBonus = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Class = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    CharacterAlignment = table.Column<string>(nullable: true),
                    Inspiration = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Background = table.Column<string>(nullable: true),
                    IniativeBonus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStats", x => x.CharacterStatsId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyState",
                columns: table => new
                {
                    CurrencyStateId = table.Column<Guid>(nullable: false),
                    Copper = table.Column<int>(nullable: false),
                    Silver = table.Column<int>(nullable: false),
                    Electrum = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Platinum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyState", x => x.CurrencyStateId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterSheetId = table.Column<Guid>(nullable: false),
                    CurrencyStateId = table.Column<Guid>(nullable: true),
                    InventoryId = table.Column<Guid>(nullable: true),
                    CharacterStatsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterSheetId);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterStats_CharacterStatsId",
                        column: x => x.CharacterStatsId,
                        principalTable: "CharacterStats",
                        principalColumn: "CharacterStatsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_CurrencyState_CurrencyStateId",
                        column: x => x.CurrencyStateId,
                        principalTable: "CurrencyState",
                        principalColumn: "CurrencyStateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    fk_characterSheet = table.Column<Guid>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Characters_fk_characterSheet",
                        column: x => x.fk_characterSheet,
                        principalTable: "Characters",
                        principalColumn: "CharacterSheetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterStatsId",
                table: "Characters",
                column: "CharacterStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CurrencyStateId",
                table: "Characters",
                column: "CurrencyStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_fk_characterSheet",
                table: "Players",
                column: "fk_characterSheet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterStats");

            migrationBuilder.DropTable(
                name: "CurrencyState");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");
        }
    }
}
