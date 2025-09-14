using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OIT_Startup_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Route = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QueryParams = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    MenuGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuGroups_MenuGroupId",
                        column: x => x.MenuGroupId,
                        principalTable: "MenuGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MenuGroups",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7861), true, 1, "Credenziali", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7862) },
                    { 2, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7866), true, 2, "Dashboard", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7866) },
                    { 3, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7868), true, 3, "Gestione", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7868) },
                    { 4, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7869), true, 4, "Analisi", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7869) },
                    { 5, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7870), true, 5, "Sistema", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(7870) }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "MenuGroupId", "Order", "ParentId", "QueryParams", "Route", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8005), "list", true, 1, 1, null, "\"{}\"", "/credentials", "Tutte le credenziali", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8005) },
                    { 2, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8009), "check_circle", true, 1, 2, null, "\"{\\u0022active\\u0022:true}\"", "/credentials", "Credenziali attive", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8010) },
                    { 3, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8204), "error", true, 1, 3, null, "\"{\\u0022expired\\u0022:true}\"", "/credentials", "Credenziali scadute", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8204) },
                    { 4, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8218), "update", true, 1, 4, null, "\"{\\u0022sort\\u0022:\\u0022created\\u0022,\\u0022sortDirection\\u0022:\\u0022desc\\u0022}\"", "/credentials", "Credenziali recenti", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8219) },
                    { 5, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8276), "dashboard", true, 2, 1, null, "\"{}\"", "/dashboard", "Panoramica", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8276) },
                    { 6, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8278), "bar_chart", true, 2, 2, null, "\"{}\"", "/stats", "Statistiche", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8278) },
                    { 7, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8279), "people", true, 3, 1, null, "\"{}\"", "", "Utenti", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8279) },
                    { 8, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8281), "inventory", true, 3, 2, null, "\"{}\"", "", "Prodotti", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8281) },
                    { 15, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8291), "assessment", true, 4, 1, null, "\"{}\"", "/reports", "Reports", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8291) },
                    { 16, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8293), "analytics", true, 4, 2, null, null, "", "Analytics", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8293) },
                    { 20, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8298), "tune", true, 5, 1, null, "\"{}\"", "/config", "Configurazione", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8298) },
                    { 21, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8299), "list_alt", true, 5, 2, null, "\"{}\"", "/logs", "Log Sistema", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8299) },
                    { 22, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8301), "help", true, 5, 3, null, "\"{}\"", "/support", "Supporto", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8301) },
                    { 9, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8282), "list", true, 3, 1, 7, "\"{}\"", "/users/list", "Lista Utenti", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8282) },
                    { 10, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8284), "person_add", true, 3, 2, 7, "\"{}\"", "/users/add", "Aggiungi Utente", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8284) },
                    { 11, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8285), "admin_panel_settings", true, 3, 3, 7, "\"{}\"", "/users/roles", "Ruoli & Permessi", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8285) },
                    { 12, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8287), "catalog", true, 3, 1, 8, "\"{}\"", "/products/catalog", "Catalogo", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8287) },
                    { 13, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8288), "category", true, 3, 2, 8, "\"{}\"", "/products/categories", "Categorie", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8288) },
                    { 14, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8290), "warehouse", true, 3, 3, 8, "\"{}\"", "/products/inventory", "Inventario", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8290) },
                    { 17, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8294), "insights", true, 4, 1, 16, "\"{}\"", "/analytics/overview", "Panoramica", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8294) },
                    { 18, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8295), "trending_up", true, 4, 2, 16, "\"{}\"", "/analytics/sales", "Vendite", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8295) },
                    { 19, new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8297), "traffic", true, 4, 3, 16, "\"{}\"", "/analytics/traffic", "Traffico", new DateTime(2025, 9, 14, 14, 8, 32, 239, DateTimeKind.Utc).AddTicks(8297) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroups_IsActive",
                table: "MenuGroups",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MenuGroups_Order",
                table: "MenuGroups",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_IsActive",
                table: "MenuItems",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuGroupId",
                table: "MenuItems",
                column: "MenuGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_Order",
                table: "MenuItems",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuGroups");
        }
    }
}
