using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OIT_Startup_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthenticationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemGroup = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Resource = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    GrantedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupPermissions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "IsSystemGroup", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3488), "Amministratori di sistema", true, true, "Administrators", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3489) },
                    { 2, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3491), "Utenti standard", true, true, "Users", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3491) },
                    { 3, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3493), "Manager con privilegi estesi", true, false, "Managers", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3493) }
                });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3783), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3783) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3800), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3803), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3803) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3990), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4031), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4031) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4090), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Route", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4091), "/admin/users", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Route", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4093), "/admin/users/add", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4094), "/admin/security-groups", "Gruppi Sicurezza", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4096), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4097), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4098), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4100), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4101), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4102), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4104), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4104) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4105), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4105) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4106), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4108), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4109), new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(4109) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreatedAt", "Description", "IsActive", "Name", "Resource", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Read", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3577), null, true, "Visualizza Menu", "Menu", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3577) },
                    { 2, "Manage", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3581), null, true, "Gestisci Menu", "Menu", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3581) },
                    { 3, "Read", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3582), null, true, "Visualizza Utenti", "User", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3583) },
                    { 4, "Create", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3583), null, true, "Crea Utenti", "User", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3584) },
                    { 5, "Update", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3585), null, true, "Modifica Utenti", "User", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3585) },
                    { 6, "Delete", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3587), null, true, "Elimina Utenti", "User", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3587) },
                    { 7, "Manage", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3588), null, true, "Gestisci Gruppi Sicurezza", "SecurityGroup", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3588) },
                    { 8, "Read", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3589), null, true, "Visualizza Reports", "Report", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3589) },
                    { 9, "Manage", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3590), null, true, "Gestisci Sistema", "System", new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3590) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastLoginAt", "LastName", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3753), "admin@oit.it", true, "System", true, null, "Administrator", "$2a$11$rQiU3oyF8qRUQ2PmVYxqTOKnZEPGO4TL4EW8NXZxKoGcHoSLe6LNu", null, null, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3753), "admin" });

            migrationBuilder.InsertData(
                table: "GroupPermissions",
                columns: new[] { "Id", "GrantedAt", "GrantedBy", "GroupId", "PermissionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3678), null, 1, 1 },
                    { 2, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3683), null, 1, 2 },
                    { 3, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3684), null, 1, 3 },
                    { 4, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3684), null, 1, 4 },
                    { 5, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3685), null, 1, 5 },
                    { 6, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3686), null, 1, 6 },
                    { 7, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3687), null, 1, 7 },
                    { 8, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3687), null, 1, 8 },
                    { 9, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3687), null, 1, 9 },
                    { 10, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3720), null, 2, 1 },
                    { 11, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3721), null, 2, 8 },
                    { 12, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3721), null, 3, 1 },
                    { 13, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3722), null, 3, 3 },
                    { 14, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3723), null, 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "GroupId", "UserId" },
                values: new object[] { 1, new DateTime(2025, 9, 23, 14, 41, 7, 192, DateTimeKind.Utc).AddTicks(3775), null, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermissions_GroupId_PermissionId",
                table: "GroupPermissions",
                columns: new[] { "GroupId", "PermissionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermissions_PermissionId",
                table: "GroupPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_IsActive",
                table: "Groups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_IsActive",
                table: "Permissions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Resource_Action",
                table: "Permissions",
                columns: new[] { "Resource", "Action" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId_GroupId",
                table: "UserGroups",
                columns: new[] { "UserId", "GroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsActive",
                table: "Users",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPermissions");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7861), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7866), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7866) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7868), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7868) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7869), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7869) });

            migrationBuilder.UpdateData(
                table: "MenuGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7870), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8005), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8005) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8009), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8204), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8204) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8218), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8276), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8276) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8278), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8279), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8281), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Route", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8282), "/users/list", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8282) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Route", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8284), "/users/add", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Route", "Title", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8285), "/users/roles", "Ruoli & Permessi", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8287), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8288), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8290), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8291), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8293), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8294), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8295), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8297), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8297) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8298), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8299), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8299) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8301), new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8301) });
        }
    }
}
