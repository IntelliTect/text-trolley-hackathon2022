using FuzzySharp;
using OpenAI_API;

namespace IntelliTect.TextTrolley.Web.Utility;

public static class ListTools
{
    public static List<int> GetIndincesToRemove( List<string> list1, List<string> list2)
    {
        List<int> results = new List<int>();

        foreach (var item in list2)
        {
            var found = Process.ExtractOne(item, list1);

            if (found != null && found.Score > 85)
            {
                results.Add(found.Index);
            }
        }

        return results;
    }
}