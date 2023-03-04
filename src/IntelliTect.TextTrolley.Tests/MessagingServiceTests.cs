using FluentAssertions;
using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Repositories;
using IntelliTect.TextTrolley.Data.Services;
using Moq;
using Moq.AutoMock;

namespace IntelliTect.TextTrolley.Tests;

public class MessagingServiceTests
{
    [Fact]
    public async Task WhenRequesterNotFound_ItGetsCreated()
    {
        var resolver = new AutoMocker();
        Mock<IRequesterRepository> requesterRepoMock = new();
        requesterRepoMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Requester
            { RequesterName = "Some Name", RequesterNumber = "+15095551212" });
        requesterRepoMock.Setup(x => x.ExistingByPhoneNumber(It.IsAny<string>())).ReturnsAsync((Requester)null!);
        resolver.Use(requesterRepoMock);

        var sut = resolver.CreateInstance<MessagingService>();

        var result =
            await sut.GetOrCreateRequester(new InboundMessage("SM1111", "Some body", "OK", null, "SD2222",
                "+5095551212"));

        resolver.VerifyAll();

        result.RequesterNumber.Should().Be("+15095551212");
    }

    [Fact]
    public async Task WhenRequesterFound_ItGetsReturned()
    {
        var resolver = new AutoMocker();
        Mock<IRequesterRepository> requesterRepoMock = new();
        requesterRepoMock.Verify(x => x.Create(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        requesterRepoMock.Setup(x => x.ExistingByPhoneNumber(It.IsAny<string>())).ReturnsAsync(new Requester
            { RequesterName = "Some Name", RequesterNumber = "+15095551212" });
        resolver.Use(requesterRepoMock);

        var sut = resolver.CreateInstance<MessagingService>();

        var result =
            await sut.GetOrCreateRequester(new InboundMessage("SM1111", "Some body", "OK", null, "SD2222",
                "+5095551212"));

        resolver.VerifyAll();

        result.RequesterNumber.Should().Be("+15095551212");
    }

    [Fact]
    public void WhenMessageConverted_ItSetsShoppingListToRequesterActiveList()
    {
        var resolver = new AutoMocker();
        var sut = resolver.CreateInstance<MessagingService>();

        var requester = new Requester
        {
            ActiveShoppingList = new ShoppingList
            {
                ShoppingListId = 42
            },
            RequesterId = 23,
            RequesterNumber = "+8005551212",
            RequesterName = "Foobar",
            ActiveShoppingListKey = 42
        };

        var message = new InboundMessage("Foot salt", "X1111", "OK", "Y2222", null!, "+8005551212");

        var result = sut.ConvertMessageToListItem(requester, message);

        result.Name.Should().Be(message.Body);
        result.OriginalName.Should().Be(message.Body);
        result.ShoppingList.Should().NotBeNull();
        result.ShoppingList!.ShoppingListId.Should().Be(requester.ActiveShoppingListKey);
    }

    [Fact]
    public async Task WhenAddListItem_ItCallsRepo()
    {
        var resolver = new AutoMocker();

        var sut = resolver.CreateInstance<MessagingService>();
        await sut.AddNewListItem(new() { Name = "Foo", OriginalName = "Foo", ShoppingList = null! });

        resolver.Verify<IShoppingListItemRepository>(x => x.AddItem(It.IsAny<ShoppingListItem>()), Times.Once);
    }
}