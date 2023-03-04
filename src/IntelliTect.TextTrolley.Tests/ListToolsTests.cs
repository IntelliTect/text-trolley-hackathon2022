using IntelliTect.TextTrolley.Web.Utility;
using OpenAI_API;

namespace IntelliTect.TextTrolley.Tests;

public class ListToolsTests 
{

    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<string>() { "apple", "banana" },
                new List<string>() { "banana" },
                new int[] { 1 }
            },
            new object[]
            {
                new List<string>() { "ice", "ice cream" },
                new List<string>() { "ice" },
                new int[] { 0 }
            },
            new object[]
            {
                new List<string>() { "ice", "ice cream", "shaving cream" },
                new List<string>() { "cream" },
                new int[] { 1 }
            },
            new object[]
            {
                new List<string>() { "ice", "ice cream", "shaving cream", "cream" },
                new List<string>() { "cream" },
                new int[] { 3 }
            },
            new object[]
            {
                new List<string>() { "ice", "ice cream", "shaving cream", "cream" },
                new List<string>() { "cream", "ice cream" },
                new int[] { 3,1 }
            },
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void GetIndicesInFirstListWhereInSecondList(List<string> list1, List<string> list2, int[] expectedIndices)
    {
        List<int> result =  ListTools.GetIndincesToRemove(list1, list2);

        Assert.Equal(expectedIndices, result);
    }
}

