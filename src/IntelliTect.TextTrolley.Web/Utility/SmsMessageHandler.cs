using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace IntelliTect.TextTrolley.Web.Utility;

public class SmsMessageHandler : ISmsMessageHandler
{
    private ISmsParser SmsParser { get; }

    private IListManager ListManager { get; }

    public SmsMessageHandler(ISmsParser smsParser, IListManager listManager)
    {
        SmsParser = smsParser;
        ListManager = listManager;
    }

    /// <summary>
    /// Handles an Sms message and returns a response to be sent to the user.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task<string> HandleSmsAsync(string message, int userId)
    {
        var intent = await SmsParser.InterpretUserIntent(message);
        List<string> updatedList;
        switch (intent)
        {
                        
            case UserIntent.AddItem:
                 updatedList = await ListManager.AddItemsToList(userId,await SmsParser.ParseToItemList(message));
                return $"""
                    Items added! Here is your list:

                    {updatedList.ToNewlineSeparatedString()}
                    """;

            case UserIntent.RemoveItem:
                 updatedList = await ListManager.RemoveItemsFromList(userId, await SmsParser.ParseToItemList(message));
                return $"""
                    Items removed! Here is your list:

                    {updatedList.ToNewlineSeparatedString()}
                    """;

            case UserIntent.ClearList:
                await ListManager.ClearList(userId);
                return "List cleared!";

            default:
                return "I'm sorry, I didn't understand that. Please try again. If you are adding an item, try putting the word 'add' at the start of your message.";    

        }

    }

}

public static class StringListExtensions
{
    public static string ToNewlineSeparatedString(this List<string> stringList)
    {
        return string.Join("\r\n", stringList);
    }
}
