using OpenAI_API;
using OpenAI_API.Chat;

namespace IntelliTect.TextTrolley.Web.Utility;

public class SmsParser : ISmsParser
{
    private OpenAIApi _Client;

    public SmsParser(OpenAIApi client)
    {
        _Client = client;
    }

    public async Task<bool> InterpretNegativeResponse(string text)
    {
        if (text.ToLower().Contains("n"))
        {
            return true;
        }
        return false;
    }

    public async Task<bool> InterpretPostiveResponse(string text)
    {
        if (text.ToLower().Contains("y"))
        {
            return true;
        }
        return false;
    }

    public async Task<UserIntent> InterpretUserIntent(string text)
    {
        var prompt = """
            Interpret the intent of the attached message which is from a user who wants to either 
            1. add items to a grocery list - the message will look like a shopping list or a list of items or just an item, and may have a verb synomous with add
            2. remove items from a grocery list - the message will look like a shopping list or a list of items or just an item but start with verb synomous with remove
            3. clear the entire grocery list - the message will be a single word or phrase that is synomous with clear
            4. it may be unclear - if you dont understand the message reply return this value
            5. the user may be asking for help - the message will contain the word help
            6. show or view the list - the user will be asking to see something

            Depending on the intent, return the appropriate enum numeric value of the list of options - only the number (no other text or characters).
            Message below:
            """;

        var fullPrompt = $"{prompt}\n\n" + string.Join("\n", text);

        var req = CreateRequest(fullPrompt, 100);

        var result = await _Client.Chat.CreateChatAsync(req);

        if (!result.Choices.Any())
        {
            throw new Exception("No choices returned from OpenAI");
        }

        string? enumString = result.Choices[0].Message.Content;

        // remove the newline characters from the text
        enumString = enumString.Replace("\n", "").Replace("\r", "");

        // get the first number character in the string
        int firstNumberIndex = enumString.IndexOfAny("123456".ToCharArray());

        if (firstNumberIndex < 0)
        {
            return UserIntent.Unknown;
        }


        // get the char at the first number index and convert it to an UserIntent
        return (UserIntent)int.Parse(enumString[firstNumberIndex].ToString());


    }

    public async Task<List<string>> ParseToItemList(string text)
    {

        var prompt = """
            Parse the attached message which is a grocery list using following rules.
            Ignore any starting text that is about the list, like "grocery list" or "please", or "here is my list" or "add to my list", or "remove", or "delete"
            Spell check any items that you are 100 percent are spelled wrong.
            Also please retain any quanitity information, as well as descriptions about like the size of the item, packaging, or container.
            Format the response as single string with items seperated by commas
            if there are commas in the original text, remove them. Do not add to the list!!!
            Message below:
            """;

        var fullPrompt = $"{prompt}\n\n" + string.Join("\n", text);


        var req = CreateRequest(fullPrompt, text.Length + 100);


        var result = await _Client.Chat.CreateChatAsync(req);

        if (!result.Choices.Any())
        {
            throw new Exception("No choices returned from OpenAI");
        }

        string parsedList = result.Choices[0].Message.Content;

        // remove the newline characters from the text
        parsedList = parsedList.Replace("\n", "").Replace("\r", "");

        // split the result into a list of strings and return it
        var list = parsedList.Split(",").ToList();
        return list.Select(i=>i.TrimStart()).ToList();
    }

    private ChatRequest CreateRequest(string prompt, int maxTokens)
    {
        var req = new ChatRequest()
        {
            Model = OpenAI_API.Models.Model.ChatGPTTurbo,
            Messages = new List<ChatMessage>() {
            new ChatMessage("user", prompt)
                 },
            Temperature = 0,
            MaxTokens = maxTokens,

        };

        return req;
    }
}
