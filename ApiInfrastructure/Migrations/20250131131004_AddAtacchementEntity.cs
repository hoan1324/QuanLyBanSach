using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAtacchementEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 217, DateTimeKind.Local).AddTicks(5077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 156, DateTimeKind.Local).AddTicks(8147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 216, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 216, DateTimeKind.Local).AddTicks(1817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 215, DateTimeKind.Local).AddTicks(8688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(3545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 215, DateTimeKind.Local).AddTicks(2092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 212, DateTimeKind.Local).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 224, DateTimeKind.Local).AddTicks(4351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 159, DateTimeKind.Local).AddTicks(2926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 217, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 210, DateTimeKind.Local).AddTicks(9296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 223, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 209, DateTimeKind.Local).AddTicks(9254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 223, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 207, DateTimeKind.Local).AddTicks(318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(9406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 160, DateTimeKind.Local).AddTicks(4361),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 217, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 198, DateTimeKind.Local).AddTicks(5953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 205, DateTimeKind.Local).AddTicks(5988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(7342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 197, DateTimeKind.Local).AddTicks(9186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 196, DateTimeKind.Local).AddTicks(6453),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(9013));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 195, DateTimeKind.Local).AddTicks(8342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 195, DateTimeKind.Local).AddTicks(6286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 190, DateTimeKind.Local).AddTicks(7016),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 220, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 195, DateTimeKind.Local).AddTicks(45),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 192, DateTimeKind.Local).AddTicks(6709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 191, DateTimeKind.Local).AddTicks(9130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 220, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 191, DateTimeKind.Local).AddTicks(2243),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 220, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 179, DateTimeKind.Local).AddTicks(2901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 218, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 186, DateTimeKind.Local).AddTicks(961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 219, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 178, DateTimeKind.Local).AddTicks(7409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 218, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 178, DateTimeKind.Local).AddTicks(4451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 218, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.CreateTable(
                name: "AttachmentFolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 174, DateTimeKind.Local).AddTicks(974)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 175, DateTimeKind.Local).AddTicks(2596)),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttachmentFolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_AttachmentFolders_AttachmentFolderId",
                        column: x => x.AttachmentFolderId,
                        principalTable: "AttachmentFolders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentFolderId",
                table: "Attachments",
                column: "AttachmentFolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "AttachmentFolders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "WareHouses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(7836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 217, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 216, DateTimeKind.Local).AddTicks(6655),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 156, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemConfigs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(4268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 216, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Staffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(3545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 215, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Staffs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 226, DateTimeKind.Local).AddTicks(1968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 215, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipping",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 224, DateTimeKind.Local).AddTicks(4351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 212, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 217, DateTimeKind.Local).AddTicks(1914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 159, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "QuestionAndAnswer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 223, DateTimeKind.Local).AddTicks(5375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 210, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 223, DateTimeKind.Local).AddTicks(3079),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 209, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(9406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 207, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Permission",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 217, DateTimeKind.Local).AddTicks(3913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 160, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(2788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 198, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(7342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 205, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 222, DateTimeKind.Local).AddTicks(1601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 197, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(9013),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 196, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(7079),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 195, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "IssuingUnits",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(6635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 195, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Genres",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 220, DateTimeKind.Local).AddTicks(7979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 190, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(5556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 195, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Combos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 221, DateTimeKind.Local).AddTicks(1355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 192, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 220, DateTimeKind.Local).AddTicks(9914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 191, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 220, DateTimeKind.Local).AddTicks(8792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 191, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 218, DateTimeKind.Local).AddTicks(3742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 179, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BookRatings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 219, DateTimeKind.Local).AddTicks(7856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 186, DateTimeKind.Local).AddTicks(961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Banners",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 218, DateTimeKind.Local).AddTicks(2600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 178, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ActionLogs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 1, 24, 20, 48, 20, 218, DateTimeKind.Local).AddTicks(2032),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 1, 31, 20, 10, 3, 178, DateTimeKind.Local).AddTicks(4451));
        }
    }
}
