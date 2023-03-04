using IntelliTect.TextTrolley.Data;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;
using OpenAI_API.Completions;
using static System.Net.Mime.MediaTypeNames;

namespace IntelliTect.TextTrolley.Web.Utility;

public class ListManager : IListManager
{
    private readonly AppDbContext _dbContext;


    public ListManager(AppDbContext context)
    {
        _dbContext = context;
    }


    Task<List<string>> IListManager.AddItemsToList(int userId, List<string> items)
    {
        throw new NotImplementedException();
    }

    async Task<List<string>> IListManager.RemoveItemsFromList(int userId, List<string> items)
    {
        var list = await _dbContext.ShoppingList.FirstAsync(l => l.Requester.RequesterId == userId);

        var stringList = list.Items.Select(i => new { i.Name, i.ShoppingListItemId}).ToList();

        var indices = ListTools.GetIndincesToRemove(stringList.Select(i=>i.Name).ToList(), items);


        var idsOfItemsToRemove = indices.Select(i => stringList[i].ShoppingListItemId);

        // probably a more eloquent way to do this
        foreach (int id in idsOfItemsToRemove) {
            list.Items.RemoveAll(item => item.ShoppingListItemId == id);
        }
        await _dbContext.SaveChangesAsync();
        return list.Items.Select(i => i.Name).ToList();

    }

    async Task<List<string>> IListManager.GetList(int userId)
    {
       var list= await  _dbContext.ShoppingList.FirstAsync(l => l.Requester.RequesterId == userId);

        return list.Items.Select(i => i.Name).ToList();
    }

    Task IListManager.ClearList(int userId)
    {
        throw new NotImplementedException();
    }

}
