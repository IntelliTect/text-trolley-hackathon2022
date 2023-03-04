using IntelliTect.TextTrolley.Web.Utility;
using OpenAI_API;

namespace IntelliTect.TextTrolley.Tests;

public class SmsParsingTests : IClassFixture<SmsParserFixture>
{
    SmsParserFixture _Fixture;

    public SmsParsingTests(SmsParserFixture fixture)
    {
        this._Fixture = fixture;
    }

    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { "add apple, banana, cherry", 3 },
            new object[] { "add grape, kiwi, lemon, orange", 4 },
            new object[] { "please add pear, watermelon", 2 },
            new object[] { "\"eggs bacon cheese icecream donuts whole milk heavy cream\"", 7 },
            new object[]
            {
                "add to my list fruit\r\nmilk\r\nchips\r\nbread\r\nstuff for dinner\r\n\r\n",
                5
            },
            new object[]
            {
                "add to my list 1x dragonfruit\r\n2x quinoa bags\r\na dozen eggz\r\n1 can chickpeaz\r\n1 jar of mermaid sauce\r\n2 lb. grass-fed beaf\r\n1 bundle of unicorn kale\r\n1 loaf of artisanal sourdough bred\r\n1 box of frosted flakz cereal",
                9
            }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public async Task ParseMessageIntoListList_GetsCloseEnough(string list, int expectedCount)
    {
        List<string> result = await _Fixture.SmsParser.ParseToItemList(list);
        if (result.Count < expectedCount)
        {
            Assert.Fail(string.Join(", ", result));
        }
    }

    public static IEnumerable<object[]> IntentTestData =>
        new List<object[]>
        {
            new object[] { "Add apple, banana, cherry", UserIntent.AddItem },
            new object[] { "delete grape, kiwi, lemon, orange", UserIntent.RemoveItem },
            new object[] { "Add pear, watermelon", UserIntent.AddItem },
            new object[]
            {
                "\"eggs bacon cheese icecream donuts whole milk heavy cream\"",
                UserIntent.AddItem
            },
            new object[]
            {
                "remove fruit\r\nmilk\r\nchips\r\nbread\r\nstuff for dinner\r\n\r\n",
                UserIntent.RemoveItem
            },
            new object[]
            {
                "Please Add 1x dragonfruit\r\n2x quinoa bags\r\na dozen eggz\r\n1 can chickpeaz\r\n1 jar of mermaid sauce\r\n2 lb. grass-fed beaf\r\n1 bundle of unicorn kale\r\n1 loaf of artisanal sourdough bred\r\n1 box of frosted flakz cereal",
                UserIntent.AddItem
            },
            new object[] { "1x dragonfruit\r\n", UserIntent.AddItem },
            new object[] { "dragonfruit\r\n", UserIntent.AddItem },
            new object[] { "help\r\n", UserIntent.Help },
            new object[] { "show list\r\n", UserIntent.ViewList },
            new object[] { "whats on my list?\r\n", UserIntent.ViewList },
            new object[] { "toilet paper\r\n", UserIntent.AddItem }
        };

    [Theory]
    [MemberData(nameof(IntentTestData))]
    public async Task ParseMessageIntent_GetsCloseEnough(string list, UserIntent userIntent)
    {
        var intent = await _Fixture.SmsParser.InterpretUserIntent(list);

        Assert.Equal(userIntent, intent);
    }
}

public class SmsParserFixture : IDisposable
{
    public ISmsParser SmsParser { get; private set; }

    public SmsParserFixture()
    {
        SecretProvider secretProvider = new SecretProvider();

        var apiKey = secretProvider.GetSecret("OpenApiToken").GetAwaiter().GetResult();

        var openai = new OpenAIAPI(apiKey);

        SmsParser = new SmsParser(openai);
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }
}
