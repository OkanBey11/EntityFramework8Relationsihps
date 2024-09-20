using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework8Relationsihps.Migrations
{
    /// <inheritdoc />
    public partial class CharacterWeaponsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Weapons_WeaponId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_WeaponId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Weapons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponId",
                table: "Weapons",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Weapons_WeaponId",
                table: "Weapons",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }
    }
}
