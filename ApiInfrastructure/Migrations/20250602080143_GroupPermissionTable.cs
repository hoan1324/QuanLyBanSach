using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GroupPermissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(8115),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 234, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(3531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 211, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 57, DateTimeKind.Local).AddTicks(2335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 210, DateTimeKind.Local).AddTicks(3171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(1249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 233, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "SystemConfigs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "SystemConfigs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(9870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 233, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(7479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 232, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Staffs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 71, DateTimeKind.Local).AddTicks(5352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 231, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(4884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 212, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 70, DateTimeKind.Local).AddTicks(8964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 230, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 69, DateTimeKind.Local).AddTicks(8435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 229, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(8822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 212, DateTimeKind.Local).AddTicks(6104));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupPermissionId",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(6635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 227, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(4146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 226, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(9158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 226, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(5674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 225, DateTimeKind.Local).AddTicks(5326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(4913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 225, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "IssuingUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "IssuingUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(8212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(2585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 225, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(4673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Combos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Combos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Combos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(2048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(9709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(4167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 215, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 63, DateTimeKind.Local).AddTicks(9398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 220, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(2056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 215, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(9456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 213, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Attachments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AttachmentFolders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(5561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 213, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(1179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 215, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "ActionLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_GroupPermissions_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId",
                principalTable: "GroupPermissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_GroupPermissions_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropTable(
                name: "GroupPermissions");

            migrationBuilder.DropIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SystemConfigs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SystemConfigs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SystemConfigs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "IssuingUnits");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "IssuingUnits");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "IssuingUnits");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ActionLogs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ActionLogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 234, DateTimeKind.Local).AddTicks(1310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 211, DateTimeKind.Local).AddTicks(8458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 210, DateTimeKind.Local).AddTicks(3171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 57, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 233, DateTimeKind.Local).AddTicks(4052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 73, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 233, DateTimeKind.Local).AddTicks(2530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 232, DateTimeKind.Local).AddTicks(9027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 72, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 231, DateTimeKind.Local).AddTicks(5835),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 71, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 212, DateTimeKind.Local).AddTicks(551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 230, DateTimeKind.Local).AddTicks(8526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 70, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 230, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 229, DateTimeKind.Local).AddTicks(1220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 69, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 212, DateTimeKind.Local).AddTicks(6104),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 58, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 227, DateTimeKind.Local).AddTicks(766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 228, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 226, DateTimeKind.Local).AddTicks(7065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 68, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 226, DateTimeKind.Local).AddTicks(248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 225, DateTimeKind.Local).AddTicks(5326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 225, DateTimeKind.Local).AddTicks(4372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 225, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 67, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(9442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(5706),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 66, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 223, DateTimeKind.Local).AddTicks(2838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 65, DateTimeKind.Local).AddTicks(9709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 215, DateTimeKind.Local).AddTicks(8683),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 220, DateTimeKind.Local).AddTicks(2077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 63, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 215, DateTimeKind.Local).AddTicks(5628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 213, DateTimeKind.Local).AddTicks(7301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AttachmentFolders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 213, DateTimeKind.Local).AddTicks(2254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 59, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 3, 11, 16, 50, 35, 215, DateTimeKind.Local).AddTicks(4461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 6, 2, 15, 1, 42, 61, DateTimeKind.Local).AddTicks(1179));
        }
    }
}
