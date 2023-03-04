namespace IntelliTect.TextTrolley.Web.Utility;

public interface IListManager
{
    Task<List<string>> AddItemsToList(string userId, List<string> items);

    Task<List<string>> RemoveItemsFromList(string userId, List<string> items);

    Task<List<string>> GetList(string userId);

    Task ClearList(string userId);
}