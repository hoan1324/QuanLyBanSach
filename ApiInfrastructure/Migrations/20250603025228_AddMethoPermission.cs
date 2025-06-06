using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMethoPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_GroupPermissions_GroupPermissionId",
                table: "Permission");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 714, DateTimeKind.Local).AddTicks(491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 705, DateTimeKind.Local).AddTicks(3804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 704, DateTimeKind.Local).AddTicks(7783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 57, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 713, DateTimeKind.Local).AddTicks(6863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 713, DateTimeKind.Local).AddTicks(6120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 713, DateTimeKind.Local).AddTicks(4776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 712, DateTimeKind.Local).AddTicks(8018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 71, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 705, DateTimeKind.Local).AddTicks(4532),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 712, DateTimeKind.Local).AddTicks(4353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 70, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 711, DateTimeKind.Local).AddTicks(8527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 69, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 705, DateTimeKind.Local).AddTicks(6880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 711, DateTimeKind.Local).AddTicks(2179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 711, DateTimeKind.Local).AddTicks(865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(8013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(6027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(5546),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupPermissions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 706, DateTimeKind.Local).AddTicks(625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GroupPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(6492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(4320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(9958),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(8522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(7383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 707, DateTimeKind.Local).AddTicks(1761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 708, DateTimeKind.Local).AddTicks(5878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 63, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 707, DateTimeKind.Local).AddTicks(613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 706, DateTimeKind.Local).AddTicks(3424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AttachmentFolders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 706, DateTimeKind.Local).AddTicks(1259),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 707, DateTimeKind.Local).AddTicks(115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_GroupPermissions_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId",
                principalTable: "GroupPermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_GroupPermissions_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GroupPermissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(8115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 714, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(3531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 705, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 57, DateTimeKind.Local).AddTicks(2335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 704, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(1249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 713, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(9870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 713, DateTimeKind.Local).AddTicks(6120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(7479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 713, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 71, DateTimeKind.Local).AddTicks(5352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 712, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(4884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 705, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 70, DateTimeKind.Local).AddTicks(8964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 712, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 69, DateTimeKind.Local).AddTicks(8435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 711, DateTimeKind.Local).AddTicks(8527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(8822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 705, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(6635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 711, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(4146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 711, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(9158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(5674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(4913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(5546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "GroupPermissions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 706, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(8212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(6492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(2585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 710, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(4673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(2048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(9709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 709, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(4167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 707, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 63, DateTimeKind.Local).AddTicks(9398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 708, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(2056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 707, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(9456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 706, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AttachmentFolders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(5561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 706, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(1179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 3, 9, 52, 27, 707, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_GroupPermissions_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId",
                principalTable: "GroupPermissions",
                principalColumn: "Id");
        }
    }
}
