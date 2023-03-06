namespace MessagingDemo;

using System.Data.SqlTypes;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Twilio.AspNet.Common;

internal class Program
{
    async static Task Main(string[] args)
    {
        var host = "https://localhost:5818";
        var phoneNumber = "+15094665265";

        HttpClient client = new HttpClient() { BaseAddress = new Uri($"{host}/api/messaging/") };

        Console.WriteLine(
            "Enter messsages and press enter to send it to the server. Responses will be printed."
        );

        ConsoleSpinner spinner = new ConsoleSpinner();

        while (true)
        {
            string body = Console.ReadLine();

            SmsRequest request = CreateRequest(body, phoneNumber);

            FormUrlEncodedContent content = EncodeRequest(request);

            Console.WriteLine();
            spinner.Start();
            HttpResponseMessage response = await client.PostAsync("ReceiveMessage", content);
            spinner.Stop();
            Console.WriteLine();

            if (response.IsSuccessStatusCode)
            {
                var responseXml = await response.Content.ReadAsStringAsync();
                XDocument doc = XDocument.Parse(responseXml);
                string message = doc.Descendants("Message").First().Value.Trim();

                PrintResponse(message);
            }
            else
            {
                Console.WriteLine("Error! Please retry");
            }
            Console.WriteLine();
        }
    }

    private static FormUrlEncodedContent EncodeRequest(SmsRequest request)
    {
        var content = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                { nameof(SmsRequest.Body), request.Body },
                { nameof(SmsRequest.From), request.From }
            }
        );

        return content;
    }

    private static void PrintResponse(string jsonResponse)
    {
        string text = jsonResponse;
        string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);

        string indentedText = string.Join(
            "\n",
            lines.Select(line => "\t\t\t\t" + line)
        );

        Console.WriteLine(indentedText);
    }

    private static SmsRequest CreateRequest(string body, string phoneNumber)
    {
        return new SmsRequest()
        {
            Body = body,
            From = phoneNumber,
            OptOutType = "foo",
            MessageSid = "foo",
            MessageStatus = "success",
            MessagingServiceSid = "foo"
        };
    }
}

public class Test
{
    public string? Foo { get; set; }
}

// Define a custom naming policy to lowercase the first letter of each property
public class LowercaseFirstLetterNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }
        var firstChar = char.ToLowerInvariant(name[0]);
        if (name.Length == 1)
        {
            return firstChar.ToString();
        }
        return firstChar + name.Substring(1);
    }
}
