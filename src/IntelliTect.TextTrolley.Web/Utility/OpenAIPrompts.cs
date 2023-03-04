using OpenAI_API;
using OpenAI_API.Completions;

namespace IntelliTect.TextTrolley.Web.Utility;

public static class OpenAiPrompts 
{
    

    public static async Task<List<int>> GetIndincesToRemove(OpenAIAPI openAIAPI, List<string> list1, List<string> list2)
    {

        var prompt = $"""
              Given two lists that have similar content, for any item found in both lists, give me the index of where it is found in the first list.
              The items just have to be somewhat similar. There may be typo differences. Return the indexes as a comma seperated list. Only include the index: nothing about the item. Do not provide a solution or explanation, just the answer.
              Please use 0 based index.
              List 1:
              {list1.ToNewlineSeparatedString()}

              List 2:
              {list2.ToNewlineSeparatedString()}
              """
       ;


        CompletionRequest completion = new CompletionRequest() { Temperature = .7  };
        completion.Prompt = prompt;
        completion.MaxTokens = 100;
        
  
        var result = await openAIAPI.Completions.CreateCompletionAsync(completion);
        

        if (!result.Completions.Any())
        {

            throw new Exception("No completions returned");
        }

        string? indices = result.Completions[0].Text;

        // remove the newline characters from the text
        indices = indices.Replace("\n", "").Replace("\r", "");


        var indexStrings = indices.Split(",");

        return indexStrings.Select(x => int.Parse(x)).ToList();

    }

  
}
