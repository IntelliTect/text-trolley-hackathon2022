using IntelliTect.TextTrolley.Web.Utility;
using OpenAI_API;

namespace IntelliTect.TextTrolley.Tests;

public class OpenAiPromptTests : IClassFixture<OpenAiPromptFixture>
{
    OpenAiPromptFixture _Fixture;

    public OpenAiPromptTests(OpenAiPromptFixture fixture)
    {
        this._Fixture = fixture;
    }

    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<string>() { "apple", "banana" },
                new List<string>() { "banana" },
                new int[] { 1 }
            },
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public async Task GetIndicesInFirstListWhereInSecondList(List<string> list1, List<string> list2, int[] expectedIndices)
    {
        List<int> result = await OpenAiPrompts.GetIndincesToRemove(_Fixture.OpenAi, list1, list2);

        Assert.Equal(expectedIndices, result);
    }
}

public class OpenAiPromptFixture : IDisposable
{
    public OpenAIAPI OpenAi { get; private set; }

    public OpenAiPromptFixture()
    {
        SecretProvider secretProvider = new SecretProvider();

        var apiKey = secretProvider.GetSecret("OpenApiToken").GetAwaiter().GetResult();

        OpenAi = new OpenAIAPI(apiKey);
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }
}
