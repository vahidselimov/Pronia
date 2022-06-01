using Microsoft.EntityFrameworkCore.Migrations;

namespace Pronia_start.Migrations
{
    public partial class CreatedAnotherSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnotherSettingId",
                table: "SocialMedias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnotherSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    AnotherSettingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotherSetting_AnotherSetting_AnotherSettingId",
                        column: x => x.AnotherSettingId,
                        principalTable: "AnotherSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_AnotherSettingId",
                table: "SocialMedias",
                column: "AnotherSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotherSetting_AnotherSettingId",
                table: "AnotherSetting",
                column: "AnotherSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotherSetting_Key",
                table: "AnotherSetting",
                column: "Key",
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_AnotherSetting_AnotherSettingId",
                table: "SocialMedias",
                column: "AnotherSettingId",
                principalTable: "AnotherSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_AnotherSetting_AnotherSettingId",
                table: "SocialMedias");

            migrationBuilder.DropTable(
                name: "AnotherSetting");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_AnotherSettingId",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "AnotherSettingId",
                table: "SocialMedias");
        }
    }
}
