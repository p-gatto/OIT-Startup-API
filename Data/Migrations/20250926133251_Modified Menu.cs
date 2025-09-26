using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OIT_Startup_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

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
                columns: new[] { "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7773), "Menu", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7773) });

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
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7791), "/menu", "Tutte le voci di menu", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7791) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7794), "/menu", "Voci di menu attive", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7795) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8016), "/menu", "Voci di menu scadute", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8028), "/menu", "Voci di menu recenti", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8028) });

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
                columns: new[] { "CreatedAt", "Icon", "Order", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8094), "list", 1, 7, "/admin/users", "Lista Utenti", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8094) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Icon", "Order", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8096), "person_add", 2, "/admin/users/create", "Aggiungi Utente", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Icon", "Order", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8097), "admin_panel_settings", 3, "/admin/security-groups", "Gruppi Sicurezza", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8097) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "Order", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8098), "assessment", 4, 1, null, "/reports", "Reports", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8100), "tune", 5, null, "/config", "Configurazione", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8101), "list_alt", 5, null, "/logs", "Log Sistema", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8102), "help", 5, null, "/support", "Supporto", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(8102) });

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
                columns: new[] { "CreatedAt", "Resource", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7546), "Group", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7547) });

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
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7738), "$2a$11$007pBGqjmpMkk25IEHbKrO9Utd59B18AKoi2XCT8EK38mmgqAl9D6", new DateTime(2025, 9, 26, 13, 32, 50, 595, DateTimeKind.Utc).AddTicks(7738) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 8,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 9,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 10,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 11,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 12,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 13,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "GroupPermissions",
                keyColumn: "Id",
                keyValue: 14,
                column: "GrantedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3488), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3489) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3491), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3493), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3783), "Credenziali", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3783) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3785), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3785) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3786), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3786) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3787), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3788), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3800), "/credentials", "Tutte le credenziali", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3803), "/credentials", "Credenziali attive", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3803) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3990), "/credentials", "Credenziali scadute", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4031), "/credentials", "Credenziali recenti", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4086), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4087), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4087) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4089), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Icon", "Order", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4090), "inventory", 2, null, "", "Prodotti", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Icon", "Order", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4091), "list", 1, "/admin/users", "Lista Utenti", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Icon", "Order", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4093), "person_add", 2, "/admin/users/add", "Aggiungi Utente", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "Order", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4094), "admin_panel_settings", 3, 3, 7, "/admin/security-groups", "Gruppi Sicurezza", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4096), "catalog", 3, 8, "/products/catalog", "Catalogo", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4097), "category", 3, 8, "/products/categories", "Categorie", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Icon", "MenuGroupId", "ParentId", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4098), "warehouse", 3, 8, "/products/inventory", "Inventario", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "MenuGroupId", "Order", "ParentId", "QueryParams", "Route", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 15, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4100), "assessment", true, 4, 1, null, "\"{}\"", "/reports", "Reports", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4100) },
                    { 16, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4101), "analytics", true, 4, 2, null, null, "", "Analytics", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4101) },
                    { 20, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4106), "tune", true, 5, 1, null, "\"{}\"", "/config", "Configurazione", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4107) },
                    { 21, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4108), "list_alt", true, 5, 2, null, "\"{}\"", "/logs", "Log Sistema", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4108) },
                    { 22, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4109), "help", true, 5, 3, null, "\"{}\"", "/support", "Supporto", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4109) }
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3577), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3577) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3581), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3581) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3582), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3583) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3583), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3585), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3585) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3587), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3587) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Resource", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3588), "SecurityGroup", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3589), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3589) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3590), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssignedAt",
                value: new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3753), "$2a$11$rQiU3oyF8qRUQ2PmVYxqTOKnZEPGO4TL4EW8NXZxKoGcHoSLe6LNu", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3753) });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "MenuGroupId", "Order", "ParentId", "QueryParams", "Route", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 17, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4102), "insights", true, 4, 1, 16, "\"{}\"", "/analytics/overview", "Panoramica", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4103) },
                    { 18, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4104), "trending_up", true, 4, 2, 16, "\"{}\"", "/analytics/sales", "Vendite", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4104) },
                    { 19, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4105), "traffic", true, 4, 3, 16, "\"{}\"", "/analytics/traffic", "Traffico", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4105) }
                });
        }
    }
}
