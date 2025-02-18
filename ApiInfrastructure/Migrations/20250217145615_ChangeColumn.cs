using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffName",
                table: "Staffs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JobName",
                table: "Jobs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Books",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 439, DateTimeKind.Local).AddTicks(8750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 934, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 415, DateTimeKind.Local).AddTicks(949),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 907, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 439, DateTimeKind.Local).AddTicks(815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 932, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 438, DateTimeKind.Local).AddTicks(9142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 932, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 438, DateTimeKind.Local).AddTicks(6336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 932, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 437, DateTimeKind.Local).AddTicks(1739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 930, DateTimeKind.Local).AddTicks(8584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 416, DateTimeKind.Local).AddTicks(1445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 908, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 436, DateTimeKind.Local).AddTicks(3406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 929, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 435, DateTimeKind.Local).AddTicks(7761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 929, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 434, DateTimeKind.Local).AddTicks(6897),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 928, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 416, DateTimeKind.Local).AddTicks(5971),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 909, DateTimeKind.Local).AddTicks(3945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 433, DateTimeKind.Local).AddTicks(216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 926, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 434, DateTimeKind.Local).AddTicks(1533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 927, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 432, DateTimeKind.Local).AddTicks(7660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 926, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 432, DateTimeKind.Local).AddTicks(1851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 925, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 431, DateTimeKind.Local).AddTicks(7695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 925, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 431, DateTimeKind.Local).AddTicks(6891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 925, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 425, DateTimeKind.Local).AddTicks(1424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 919, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 431, DateTimeKind.Local).AddTicks(4076),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 924, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 430, DateTimeKind.Local).AddTicks(3896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 923, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 429, DateTimeKind.Local).AddTicks(9584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 923, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 429, DateTimeKind.Local).AddTicks(5625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 923, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 419, DateTimeKind.Local).AddTicks(8579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 912, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 422, DateTimeKind.Local).AddTicks(8607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 916, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 419, DateTimeKind.Local).AddTicks(5854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 912, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 417, DateTimeKind.Local).AddTicks(7428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 910, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AttachmentFolders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 417, DateTimeKind.Local).AddTicks(1180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 909, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 419, DateTimeKind.Local).AddTicks(4740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 912, DateTimeKind.Local).AddTicks(4170));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Staffs",
                newName: "StaffName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jobs",
                newName: "JobName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "BookName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 934, DateTimeKind.Local).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 439, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 907, DateTimeKind.Local).AddTicks(7367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 415, DateTimeKind.Local).AddTicks(949));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 932, DateTimeKind.Local).AddTicks(9353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 439, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 932, DateTimeKind.Local).AddTicks(7430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 438, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 932, DateTimeKind.Local).AddTicks(4044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 438, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 930, DateTimeKind.Local).AddTicks(8584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 437, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 908, DateTimeKind.Local).AddTicks(8695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 416, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 929, DateTimeKind.Local).AddTicks(9925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 436, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 929, DateTimeKind.Local).AddTicks(4448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 435, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 928, DateTimeKind.Local).AddTicks(4950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 434, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 909, DateTimeKind.Local).AddTicks(3945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 416, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 926, DateTimeKind.Local).AddTicks(6893),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 433, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 927, DateTimeKind.Local).AddTicks(9478),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 434, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 926, DateTimeKind.Local).AddTicks(3587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 432, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 925, DateTimeKind.Local).AddTicks(8229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 432, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 925, DateTimeKind.Local).AddTicks(3596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 431, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 925, DateTimeKind.Local).AddTicks(2683),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 431, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 919, DateTimeKind.Local).AddTicks(969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 425, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 924, DateTimeKind.Local).AddTicks(9384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 431, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 923, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 430, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 923, DateTimeKind.Local).AddTicks(4891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 429, DateTimeKind.Local).AddTicks(9584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 923, DateTimeKind.Local).AddTicks(1770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 429, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 912, DateTimeKind.Local).AddTicks(8817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 419, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 916, DateTimeKind.Local).AddTicks(4364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 422, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 912, DateTimeKind.Local).AddTicks(5500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 419, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 910, DateTimeKind.Local).AddTicks(6392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 417, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AttachmentFolders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 909, DateTimeKind.Local).AddTicks(9983),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 417, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 2, 3, 9, 12, 8, 912, DateTimeKind.Local).AddTicks(4170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 2, 17, 21, 56, 14, 419, DateTimeKind.Local).AddTicks(4740));
        }
    }
}
