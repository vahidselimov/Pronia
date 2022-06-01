using Microsoft.EntityFrameworkCore.Migrations;

namespace Pronia_start.Migrations
{
    public partial class SocialMediasUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnotherSetting_AnotherSetting_AnotherSettingId",
                table: "AnotherSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_AnotherSetting_AnotherSettingId",
                table: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnotherSetting",
                table: "AnotherSetting");

            migrationBuilder.DropIndex(
                name: "IX_AnotherSetting_AnotherSettingId",
                table: "AnotherSetting");

            migrationBuilder.DropColumn(
                name: "AnotherSettingId",
                table: "AnotherSetting");

            migrationBuilder.RenameTable(
                name: "AnotherSetting",
                newName: "anotherSettings");

            migrationBuilder.RenameIndex(
                name: "IX_AnotherSetting_Key",
                table: "anotherSettings",
                newName: "IX_anotherSettings_Key");

            migrationBuilder.AddPrimaryKey(
                name: "PK_anotherSettings",
                table: "anotherSettings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_anotherSettings_AnotherSettingId",
                table: "SocialMedias",
                column: "AnotherSettingId",
                principalTable: "anotherSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_anotherSettings_AnotherSettingId",
                table: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_anotherSettings",
                table: "anotherSettings");

            migrationBuilder.RenameTable(
                name: "anotherSettings",
                newName: "AnotherSetting");

            migrationBuilder.RenameIndex(
                name: "IX_anotherSettings_Key",
                table: "AnotherSetting",
                newName: "IX_AnotherSetting_Key");

            migrationBuilder.AddColumn<int>(
                name: "AnotherSettingId",
                table: "AnotherSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnotherSetting",
                table: "AnotherSetting",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnotherSetting_AnotherSettingId",
                table: "AnotherSetting",
                column: "AnotherSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnotherSetting_AnotherSetting_AnotherSettingId",
                table: "AnotherSetting",
                column: "AnotherSettingId",
                principalTable: "AnotherSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_AnotherSetting_AnotherSettingId",
                table: "SocialMedias",
                column: "AnotherSettingId",
                principalTable: "AnotherSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
