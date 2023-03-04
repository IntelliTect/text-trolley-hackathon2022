namespace IntelliTect.TextTrolley.Web.Utility;

public interface ISmsParser
{

    // a method called ParseToItemList that takes a string and returns a list of Item objects
    Task<List<string>> ParseToItemList(string text);

    // a method called Interprept Postive response that checks if the string is a positive response
    Task<bool> InterpretPostiveResponse(string text);

    // a method called Interpret Negative response that checks if the string is a negative response
    Task<bool> InterpretNegativeResponse(string text);

    // a method called Interpret Negative response that checks if the string is a negative response
    Task<UserIntent> InterpretUserIntent(string text);

}