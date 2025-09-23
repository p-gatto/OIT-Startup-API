using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace OIT_Startup_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Menu entities
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }


        // User and Security entities
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }

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

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.IsActive);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(20);
            });

            // SecurityGroup configuration
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.IsActive);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // UserSecurityGroup configuration
            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.GroupId }).IsUnique();

                entity.HasOne(e => e.User)
                      .WithMany(e => e.UserGroups)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Group)
                      .WithMany(e => e.UserGroups)
                      .HasForeignKey(e => e.GroupId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Permission configuration
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => new { e.Resource, e.Action }).IsUnique();
                entity.HasIndex(e => e.IsActive);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Resource).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Action).IsRequired().HasMaxLength(50);
            });

            // SecurityGroupPermission configuration
            modelBuilder.Entity<GroupPermission>(entity =>
            {
                entity.HasIndex(e => new { e.GroupId, e.PermissionId }).IsUnique();

                entity.HasOne(e => e.Group)
                      .WithMany(e => e.GroupPermissions)
                      .HasForeignKey(e => e.GroupId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Permission)
                      .WithMany(e => e.GroupPermissions)
                      .HasForeignKey(e => e.PermissionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed SecurityGroups
            var adminGroup = new Group { Id = 1, Name = "Administrators", Description = "Amministratori di sistema", IsSystemGroup = true };
            var userGroup = new Group { Id = 2, Name = "Users", Description = "Utenti standard", IsSystemGroup = true };
            var managerGroup = new Group { Id = 3, Name = "Managers", Description = "Manager con privilegi estesi", IsSystemGroup = false };

            modelBuilder.Entity<Group>().HasData(adminGroup, userGroup, managerGroup);

            // Seed Permissions
            var permissions = new List<Permission>
            {
                new Permission { Id = 1, Name = "Visualizza Menu", Resource = "Menu", Action = "Read" },
                new Permission { Id = 2, Name = "Gestisci Menu", Resource = "Menu", Action = "Manage" },
                new Permission { Id = 3, Name = "Visualizza Utenti", Resource = "User", Action = "Read" },
                new Permission { Id = 4, Name = "Crea Utenti", Resource = "User", Action = "Create" },
                new Permission { Id = 5, Name = "Modifica Utenti", Resource = "User", Action = "Update" },
                new Permission { Id = 6, Name = "Elimina Utenti", Resource = "User", Action = "Delete" },
                new Permission { Id = 7, Name = "Gestisci Gruppi Sicurezza", Resource = "SecurityGroup", Action = "Manage" },
                new Permission { Id = 8, Name = "Visualizza Reports", Resource = "Report", Action = "Read" },
                new Permission { Id = 9, Name = "Gestisci Sistema", Resource = "System", Action = "Manage" }
            };

            modelBuilder.Entity<Permission>().HasData(permissions);

            // Seed GroupPermissions (Admin ha tutti i permessi)
            var adminPermissions = permissions.Select((p, index) => new GroupPermission
            {
                Id = index + 1,
                GroupId = 1,
                PermissionId = p.Id
            }).ToArray();

            // Users hanno solo permessi base
            var userPermissions = new GroupPermission[]
            {
                new GroupPermission { Id = 10, GroupId = 2, PermissionId = 1 }, // Visualizza Menu
                new GroupPermission { Id = 11, GroupId = 2, PermissionId = 8 }  // Visualizza Reports
            };

            // Managers hanno permessi intermedi
            var managerPermissions = new GroupPermission[]
            {
                new GroupPermission { Id = 12, GroupId = 3, PermissionId = 1 }, // Visualizza Menu
                new GroupPermission { Id = 13, GroupId = 3, PermissionId = 3 }, // Visualizza Utenti
                new GroupPermission { Id = 14, GroupId = 3, PermissionId = 8 }  // Visualizza Reports
            };

            modelBuilder.Entity<GroupPermission>().HasData(adminPermissions.Concat(userPermissions).Concat(managerPermissions));

            // Seed default admin user (password: "Admin123!")
            var adminUser = new User
            {
                Id = 1,
                FirstName = "System",
                LastName = "Administrator",
                Email = "admin@oit.it",
                Username = "admin",
                PasswordHash = "$2a$11$rQiU3oyF8qRUQ2PmVYxqTOKnZEPGO4TL4EW8NXZxKoGcHoSLe6LNu", // Admin123!
                IsActive = true,
                EmailConfirmed = true
            };

            modelBuilder.Entity<User>().HasData(adminUser);

            // Assegna gruppo Admin all'utente admin
            modelBuilder.Entity<UserGroup>().HasData(new UserGroup
            {
                Id = 1,
                UserId = 1,
                GroupId = 1
            });

            // Seed menu data (existing)
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
                new MenuItem { Id = 9, Title = "Lista Utenti", Icon = "list", Route = "/admin/users", QueryParams = "{}", Order = 1, MenuGroupId = 3, ParentId = 7 },
                new MenuItem { Id = 10, Title = "Aggiungi Utente", Icon = "person_add", Route = "/admin/users/add", QueryParams = "{}", Order = 2, MenuGroupId = 3, ParentId = 7 },
                new MenuItem { Id = 11, Title = "Gruppi Sicurezza", Icon = "admin_panel_settings", Route = "/admin/security-groups", QueryParams = "{}", Order = 3, MenuGroupId = 3, ParentId = 7 },
                
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
                .Where(e => e.Entity is MenuGroup || e.Entity is MenuItem ||
                           e.Entity is User || e.Entity is Group || e.Entity is Permission);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    switch (entry.Entity)
                    {
                        case MenuGroup group:
                            group.CreatedAt = DateTime.UtcNow;
                            group.UpdatedAt = DateTime.UtcNow;
                            break;
                        case MenuItem item:
                            item.CreatedAt = DateTime.UtcNow;
                            item.UpdatedAt = DateTime.UtcNow;
                            break;
                        case User user:
                            user.CreatedAt = DateTime.UtcNow;
                            user.UpdatedAt = DateTime.UtcNow;
                            break;
                        case Group secGroup:
                            secGroup.CreatedAt = DateTime.UtcNow;
                            secGroup.UpdatedAt = DateTime.UtcNow;
                            break;
                        case Permission permission:
                            permission.CreatedAt = DateTime.UtcNow;
                            permission.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    switch (entry.Entity)
                    {
                        case MenuGroup group:
                            group.UpdatedAt = DateTime.UtcNow;
                            break;
                        case MenuItem item:
                            item.UpdatedAt = DateTime.UtcNow;
                            break;
                        case User user:
                            user.UpdatedAt = DateTime.UtcNow;
                            break;
                        case Group Group:
                            Group.UpdatedAt = DateTime.UtcNow;
                            break;
                        case Permission permission:
                            permission.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
        }

    }
} 