using IntelliTect.TextTrolley.Data.Models;

namespace IntelliTect.TextTrolley.Data.Repositories;

public interface IShoppingListItemRepository
{
    Task AddItem(ShoppingListItem item);
}

public class ShoppingListItemRepository : IShoppingListItemRepository
{
    public ShoppingListItemRepository(AppDbContext context)
    {
        Context = context;
    }

    protected AppDbContext Context { get; }

    public async Task AddItem(ShoppingListItem item)
    {
        await Context.ShoppingListItem.AddAsync(item);
        await Context.SaveChangesAsync();
    }
}