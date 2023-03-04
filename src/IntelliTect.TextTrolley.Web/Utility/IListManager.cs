using IntelliTect.TextTrolley.Data.Models;

namespace IntelliTect.TextTrolley.Web.Utility;

public interface IListManager
{
    Task<List<string>> AddItemsToList(Requester requester, List<string> items);

    Task<List<string>> RemoveItemsFromList(Requester requester, List<string> items);

    Task<List<string>> GetList(int userId);

    Task ClearList(int userId);
}