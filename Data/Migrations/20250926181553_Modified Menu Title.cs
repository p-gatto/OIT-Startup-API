using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OIT_Startup_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedMenuTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MenuItems",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MenuGroups",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1403), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1407), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1408), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1408) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1764), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1764) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1766), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1768), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1768) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1769), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1770), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1784), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1785) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1787), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1787) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2033), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2046), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2046) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2114), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2115), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2115) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2117), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2118), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2120), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2120) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2121), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2121) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2122), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2124), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2125), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2126), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(2126) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1505), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1509), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1511), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1512), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1513), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1516), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1516) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1517), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1518), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1520), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedAt",
                value: new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1727), new DateTime(2025, 9, 26, 18, 15, 52, 223, DateTimeKind.Utc).AddTicks(1727) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MenuItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MenuGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7434), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7435) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7438), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7439), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7773), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7775), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7777), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7778), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7778) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7778), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7779) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7791), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7791) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7794), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7795) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8016), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8028), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8090), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8091), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8091) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8093), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8093) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8094), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8096), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8097), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8098), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8100), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8101), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8102), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7536), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7539), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7539) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7541), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7542), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7543), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7545), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7546), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7547), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7548) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7548), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedAt",
                value: new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7738), new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7738) });
        }
    }
}
