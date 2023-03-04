using IntelliTect.TextTrolley.Data.Models;

namespace IntelliTect.TextTrolley.Data.Services;

public interface IMessagingService
{
    Task<Requester> GetOrCreateRequester(InboundMessage message);

    ShoppingListItem ConvertMessageToListItem(Requester requester, InboundMessage message);

    Task AddNewListItem(ShoppingListItem item);
}