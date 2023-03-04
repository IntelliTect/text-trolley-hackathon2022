using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Repositories;

namespace IntelliTect.TextTrolley.Data.Services;

public class MessagingService : IMessagingService
{
    protected IRequesterRepository RequesterRepo { get; }
    protected IShoppingListItemRepository ShoppingListItemRepo { get; }

    public MessagingService(IRequesterRepository requesterRepo, IShoppingListItemRepository shoppingListItemRepo)
    {
        RequesterRepo = requesterRepo;
        ShoppingListItemRepo = shoppingListItemRepo;
    }

    public async Task<Requester> GetOrCreateRequester(InboundMessage message)
    {
        return await RequesterRepo.ExistingByPhoneNumber(message.From) ?? await RequesterRepo.Create(message.From, "unknown sender");
    }

    public ShoppingListItem ConvertMessageToListItem(Requester requester, InboundMessage message)
    {
        return new ShoppingListItem()
        {
            Name = message.Body,
            OriginalName = message.Body,
            Purchased = false,
            ShoppingList = requester.ActiveShoppingList,
            ShoppingListItemId = requester.ActiveShoppingListKey
        };
    }

    public async Task AddNewListItem(ShoppingListItem item)
    {
        await ShoppingListItemRepo.AddItem(item);
    }
}