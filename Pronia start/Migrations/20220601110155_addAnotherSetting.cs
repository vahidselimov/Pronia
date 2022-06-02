using Microsoft.EntityFrameworkCore.Migrations;

namespace Pronia_start.Migrations
{
    public partial class addAnotherSetting : Migration
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
                newName: "AnotherSettings");

            migrationBuilder.RenameIndex(
                name: "IX_AnotherSetting_Key",
                table: "AnotherSettings",
                newName: "IX_AnotherSettings_Key");

            migrationBuilder.AlterColumn<int>(
                name: "AnotherSettingId",
                table: "SocialMedias",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnotherSettings",
                table: "AnotherSettings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_AnotherSettings_AnotherSettingId",
                table: "SocialMedias",
                column: "AnotherSettingId",
                principalTable: "AnotherSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_AnotherSettings_AnotherSettingId",
                table: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnotherSettings",
                table: "AnotherSettings");

            migrationBuilder.RenameTable(
                name: "AnotherSettings",
                newName: "AnotherSetting");

            migrationBuilder.RenameIndex(
                name: "IX_AnotherSettings_Key",
                table: "AnotherSetting",
                newName: "IX_AnotherSetting_Key");

            migrationBuilder.AlterColumn<int>(
                name: "AnotherSettingId",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
