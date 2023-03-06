using IntelliTect.TextTrolley.Data;
using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IntelliTect.TextTrolley.Web.Utility;

public class ListManager : IListManager
{
    private readonly AppDbContext _dbContext;

    public IShoppingListItemRepository ShoppingListItemRepo { get; }

    public ListManager(AppDbContext context, IShoppingListItemRepository shoppingListItemRepo)
    {
        _dbContext = context;
        ShoppingListItemRepo = shoppingListItemRepo;
    }

    public async Task<List<string>> AddItemsToList(Requester requester, List<string> items)
    {
        var convertedItems = items.Select(
            i =>
                new ShoppingListItem()
                {
                    Name = i,
                    OriginalName = i,
                    Purchased = false,
                    ShoppingList = requester.ActiveShoppingList,
                    ShoppingListId = requester.ActiveShoppingListKey
                }
        );

        foreach (ShoppingListItem item in convertedItems)
        {
            await ShoppingListItemRepo.AddItem(item);
        }

        var list = await GetUsersItems(requester.RequesterId);

        return list.Select(i=>i.Name).ToList();
    }

    async Task<List<string>> IListManager.RemoveItemsFromList(
        Requester requester,
        List<string> items
    )
    {
        var userId = requester.RequesterId;

        var existingItems = await GetUsersItems(userId);

        var stringList = existingItems.Select(i => new { i.Name, i.ShoppingListItemId }).ToList();

        var indices = ListTools.GetIndincesToRemove(stringList.Select(i => i.Name).ToList(), items);

        // might have duplicate indices need to remove those todo
        var idsOfItemsToRemove = indices.Select(i => stringList[i].ShoppingListItemId);

        var itemsToRemove = existingItems.Where(
            i => idsOfItemsToRemove.Contains(i.ShoppingListItemId)
        );

        _dbContext.ShoppingListItem.RemoveRange(itemsToRemove);

        await _dbContext.SaveChangesAsync();

        var remainingItems = existingItems.Where(
            i => !idsOfItemsToRemove.Contains(i.ShoppingListItemId)
        );
        return remainingItems.Select(i => i.Name).ToList();
    }

    async Task<List<string>> IListManager.GetList(int userId)
    {
        var items = await GetUsersItems(userId);

        return items.Select(i => i.Name).ToList();
    }

    Task IListManager.ClearList(int userId)
    {
        throw new NotImplementedException();
    }

    private async Task<List<ShoppingListItem>> GetUsersItems(int userId)
    {
        var list = await _dbContext.ShoppingList.FirstAsync(l => l.Requester.RequesterId == userId);

        var items = await _dbContext.ShoppingListItem
            .Where(i => i.ShoppingListId == list.ShoppingListId)
            .ToListAsync();

        return items;
    }
}
