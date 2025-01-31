using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreateDateInModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 565, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 547, DateTimeKind.Local).AddTicks(4233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 901, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 564, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 564, DateTimeKind.Local).AddTicks(3482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 910, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 564, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 562, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 548, DateTimeKind.Local).AddTicks(3885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 901, DateTimeKind.Local).AddTicks(6085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 561, DateTimeKind.Local).AddTicks(5124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 909, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 561, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 560, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 548, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 558, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 559, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 558, DateTimeKind.Local).AddTicks(6804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 907, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 558, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 557, DateTimeKind.Local).AddTicks(8189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 907, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 557, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 555, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 557, DateTimeKind.Local).AddTicks(4849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 907, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 556, DateTimeKind.Local).AddTicks(5878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 906, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 556, DateTimeKind.Local).AddTicks(2935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 906, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 556, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 550, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 553, DateTimeKind.Local).AddTicks(7106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 904, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 550, DateTimeKind.Local).AddTicks(5550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 903, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 550, DateTimeKind.Local).AddTicks(4489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 902, DateTimeKind.Local).AddTicks(9267));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "WareHouses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SystemConfigs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IssuingUnits");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 901, DateTimeKind.Local).AddTicks(1111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 547, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 910, DateTimeKind.Local).AddTicks(6877),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 564, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 901, DateTimeKind.Local).AddTicks(6085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 548, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 909, DateTimeKind.Local).AddTicks(4069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 561, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 907, DateTimeKind.Local).AddTicks(7098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 558, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 907, DateTimeKind.Local).AddTicks(2150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 557, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 907, DateTimeKind.Local).AddTicks(582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 557, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 906, DateTimeKind.Local).AddTicks(4940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 556, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 906, DateTimeKind.Local).AddTicks(2828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 556, DateTimeKind.Local).AddTicks(2935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 904, DateTimeKind.Local).AddTicks(8197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 553, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 903, DateTimeKind.Local).AddTicks(78),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 550, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 26, 17, 32, 19, 902, DateTimeKind.Local).AddTicks(9267),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 23, 14, 29, 37, 550, DateTimeKind.Local).AddTicks(4489));
        }
    }
}
