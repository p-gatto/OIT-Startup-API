using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace OIT_Startup_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MenuGroup configuration
            modelBuilder.Entity<MenuGroup>(entity =>
            {
                entity.HasIndex(e => e.Order);
                entity.HasIndex(e => e.IsActive);
            });

            // MenuItem configuration
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasIndex(e => e.Order);
                entity.HasIndex(e => e.IsActive);
                entity.HasIndex(e => e.ParentId);
                entity.HasIndex(e => e.MenuGroupId);

                // Self-referencing relationship
                entity.HasOne(e => e.Parent)
                      .WithMany(e => e.Children)
                      .HasForeignKey(e => e.ParentId)
                      .OnDelete(DeleteBehavior.Restrict);

                // MenuGroup relationship
                entity.HasOne(e => e.MenuGroup)
                      .WithMany(e => e.Items)
                      .HasForeignKey(e => e.MenuGroupId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Convert QueryParams to/from JSON
                entity.Property(e => e.QueryParams)
                      .HasConversion(
                          v => v == null ? null : JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                          v => v == null ? null : JsonSerializer.Deserialize<string>(v, (JsonSerializerOptions?)null)
                      );
            });

            // Seed data
            SeedMenuData(modelBuilder);
        }
        private void SeedMenuData(ModelBuilder modelBuilder)
        {
            var groups = new[]
            {
                new MenuGroup { Id = 1, Title = "Credenziali", Order = 1 },
                new MenuGroup { Id = 2, Title = "Dashboard", Order = 2 },
                new MenuGroup { Id = 3, Title = "Gestione", Order = 3 },
                new MenuGroup { Id = 4, Title = "Analisi", Order = 4 },
                new MenuGroup { Id = 5, Title = "Sistema", Order = 5 }
            };

            modelBuilder.Entity<MenuGroup>().HasData(groups);

            var menuItems = new[]
            {
                // Credenziali
                new MenuItem { Id = 1, Title = "Tutte le credenziali", Icon = "list", Route = "/credentials", QueryParams = "{}", Order = 1, MenuGroupId = 1 },
                new MenuItem { Id = 2, Title = "Credenziali attive", Icon = "check_circle", Route = "/credentials", QueryParams = JsonSerializer.Serialize(new { active = true }), Order = 2, MenuGroupId = 1 },
                new MenuItem { Id = 3, Title = "Credenziali scadute", Icon = "error", Route = "/credentials", QueryParams = JsonSerializer.Serialize(new { expired = true }), Order = 3, MenuGroupId = 1 },
                new MenuItem { Id = 4, Title = "Credenziali recenti", Icon = "update", Route = "/credentials", QueryParams = JsonSerializer.Serialize(new { sort = "created", sortDirection = "desc" }), Order = 4, MenuGroupId = 1 },
                
                // Dashboard
                new MenuItem { Id = 5, Title = "Panoramica", Icon = "dashboard", Route = "/dashboard", QueryParams = "{}", Order = 1, MenuGroupId = 2 },
                new MenuItem { Id = 6, Title = "Statistiche", Icon = "bar_chart", Route = "/stats", QueryParams = "{}", Order = 2, MenuGroupId = 2 },
                
                // Gestione - Parent items
                new MenuItem { Id = 7, Title = "Utenti", Icon = "people", Route = "", QueryParams = "{}", Order = 1, MenuGroupId = 3 },
                new MenuItem { Id = 8, Title = "Prodotti", Icon = "inventory", Route = "", QueryParams = "{}", Order = 2, MenuGroupId = 3 },
                
                // Gestione - Utenti children
                new MenuItem { Id = 9, Title = "Lista Utenti", Icon = "list", Route = "/users/list", QueryParams = "{}", Order = 1, MenuGroupId = 3, ParentId = 7 },
                new MenuItem { Id = 10, Title = "Aggiungi Utente", Icon = "person_add", Route = "/users/add", QueryParams = "{}", Order = 2, MenuGroupId = 3, ParentId = 7 },
                new MenuItem { Id = 11, Title = "Ruoli & Permessi", Icon = "admin_panel_settings", Route = "/users/roles", QueryParams = "{}", Order = 3, MenuGroupId = 3, ParentId = 7 },
                
                // Gestione - Prodotti children
                new MenuItem { Id = 12, Title = "Catalogo", Icon = "catalog", Route = "/products/catalog", QueryParams = "{}", Order = 1, MenuGroupId = 3, ParentId = 8 },
                new MenuItem { Id = 13, Title = "Categorie", Icon = "category", Route = "/products/categories", QueryParams = "{}", Order = 2, MenuGroupId = 3, ParentId = 8 },
                new MenuItem { Id = 14, Title = "Inventario", Icon = "warehouse", Route = "/products/inventory", QueryParams = "{}", Order = 3, MenuGroupId = 3, ParentId = 8 },
                
                // Analisi
                new MenuItem { Id = 15, Title = "Reports", Icon = "assessment", Route = "/reports", QueryParams = "{}", Order = 1, MenuGroupId = 4 },
                new MenuItem { Id = 16, Title = "Analytics", Icon = "analytics", Route = "", QueryParams = null, Order = 2, MenuGroupId = 4 },
                
                // Analisi - Analytics children
                new MenuItem { Id = 17, Title = "Panoramica", Icon = "insights", Route = "/analytics/overview", QueryParams = "{}", Order = 1, MenuGroupId = 4, ParentId = 16 },
                new MenuItem { Id = 18, Title = "Vendite", Icon = "trending_up", Route = "/analytics/sales", QueryParams = "{}", Order = 2, MenuGroupId = 4, ParentId = 16 },
                new MenuItem { Id = 19, Title = "Traffico", Icon = "traffic", Route = "/analytics/traffic", QueryParams = "{}", Order = 3, MenuGroupId = 4, ParentId = 16 },
                
                // Sistema
                new MenuItem { Id = 20, Title = "Configurazione", Icon = "tune", Route = "/config", QueryParams = "{}", Order = 1, MenuGroupId = 5 },
                new MenuItem { Id = 21, Title = "Log Sistema", Icon = "list_alt", Route = "/logs", QueryParams = "{}", Order = 2, MenuGroupId = 5 },
                new MenuItem { Id = 22, Title = "Supporto", Icon = "help", Route = "/support", QueryParams = "{}", Order = 3, MenuGroupId = 5 }
            };

            modelBuilder.Entity<MenuItem>().HasData(menuItems);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is MenuGroup || e.Entity is MenuItem);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is MenuGroup group)
                    {
                        group.CreatedAt = DateTime.UtcNow;
                        group.UpdatedAt = DateTime.UtcNow;
                    }
                    else if (entry.Entity is MenuItem item)
                    {
                        item.CreatedAt = DateTime.UtcNow;
                        item.UpdatedAt = DateTime.UtcNow;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is MenuGroup group)
                        group.UpdatedAt = DateTime.UtcNow;
                    else if (entry.Entity is MenuItem item)
                        item.UpdatedAt = DateTime.UtcNow;
                }
            }
        }

    }
} 