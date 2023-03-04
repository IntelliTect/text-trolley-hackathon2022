using IntelliTect.TextTrolley.Data;
using OpenAI_API;
using OpenAI_API.Completions;
using static System.Net.Mime.MediaTypeNames;

namespace IntelliTect.TextTrolley.Web.Utility;

public class ListManager : IListManager
{
    private readonly AppDbContext _dbContext;
    private readonly OpenAIAPI _openAIAPI;

    public ListManager(AppDbContext context, OpenAIAPI openAIAPI)
    {
        _dbContext = context;
        _openAIAPI = openAIAPI;
    }


    Task<List<string>> IListManager.AddItemsToList(string userId, List<string> items)
    {
        throw new NotImplementedException();
    }

    Task<List<string>> IListManager.RemoveItemsFromList(string userId, List<string> items)
    {
        // var indices =  OpenAiPrompts.GetIndincesToRemove(items)

        throw new NotImplementedException();
    }

    Task<List<string>> IListManager.GetList(string userId)
    {
        throw new NotImplementedException();
    }

    Task IListManager.ClearList(string userId)
    {
        throw new NotImplementedException();
    }
}
