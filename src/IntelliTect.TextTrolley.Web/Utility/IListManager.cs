namespace IntelliTect.TextTrolley.Web.Utility;

public interface IListManager
{
    Task<List<string>> AddItemsToList(int userId, List<string> items);

    Task<List<string>> RemoveItemsFromList(int userId, List<string> items);

    Task<List<string>> GetList(int userId);

    Task ClearList(int userId);
}