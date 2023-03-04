using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Net.NetworkInformation;

namespace IntelliTect.TextTrolley.Web.Utility;

public class SmsMessageHandler : ISmsMessageHandler
{
    public IRequesterRepository RequesterRepo { get; }
    private ISmsParser SmsParser { get; }

    private IListManager ListManager { get; }

    public SmsMessageHandler(IRequesterRepository requesterRepo, ISmsParser smsParser, IListManager listManager)
    {
        RequesterRepo = requesterRepo;
        SmsParser = smsParser;
        ListManager = listManager;
    }

    /// <summary>
    /// Handles an Sms message and returns a response to be sent to the user.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task<string> HandleSmsAsync(InboundMessage message)
    {
        var requester = await GetOrCreateRequester(message);

        var userId = requester.RequesterId;

        var intent = await SmsParser.InterpretUserIntent(message.Body);
        List<string> updatedList;
        switch (intent)
        {
                        
            case UserIntent.AddItem:
                 updatedList = await ListManager.AddItemsToList(requester,await SmsParser.ParseToItemList(message.Body));
                return $"""
                    Items added! Here is your list:

                    {updatedList.ToNewlineSeparatedString()}
                    """;

            case UserIntent.RemoveItem:
                 updatedList = await ListManager.RemoveItemsFromList(requester, await SmsParser.ParseToItemList(message.Body));
                return $"""
                    Items removed! Here is your list:

                    {updatedList.ToNewlineSeparatedString()}
                    """;

            case UserIntent.ClearList:
                await ListManager.ClearList(userId);
                return "List cleared!";

            case UserIntent.ViewList:
                var theList = await ListManager.GetList(requester.RequesterId);
                return theList.ToNewlineSeparatedString();

            case UserIntent.Help:
               
                return """
                    You can message me with an item or list of items and I will add them to your list.
                    You can say delete followed by an item or list of items and I will remove anything that matches on your list
                    You can ask for your list by saying 'show list'
                    """
                   ;

            default:
                return "I'm sorry, I didn't understand that. Please try again. Reply 'help' if you would like some tips.";    

        }

    }

    public async Task<Requester> GetOrCreateRequester(InboundMessage message)
    {
        return await RequesterRepo.ExistingByPhoneNumber(message.From) ?? await RequesterRepo.Create(message.From, "unknown sender");
    }

}

public static class StringListExtensions
{
    public static string ToNewlineSeparatedString(this List<string> stringList)
    {
        return string.Join("\r\n", stringList);
    }
}
