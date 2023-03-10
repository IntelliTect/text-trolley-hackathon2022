using Microsoft.EntityFrameworkCore;
using IntelliTect.TextTrolley.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IntelliTect.TextTrolley.Data;

[Coalesce]
public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public DbSet<ShoppingList> ShoppingList => Set<ShoppingList>();
    public DbSet<ShoppingListItem> ShoppingListItem => Set<ShoppingListItem>();
    public DbSet<Requester> Requester => Set<Requester>();


    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
