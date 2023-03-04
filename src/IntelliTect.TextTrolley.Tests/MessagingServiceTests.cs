using FluentAssertions;
using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Repositories;
using IntelliTect.TextTrolley.Data.Services;
using IntelliTect.TextTrolley.Web.Utility;
using Moq;
using Moq.AutoMock;

namespace IntelliTect.TextTrolley.Tests;

public class SmsHandlerTests
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

        var sut = resolver.CreateInstance<SmsMessageHandler>();

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

        var sut = resolver.CreateInstance<SmsMessageHandler>();

        var result =
            await sut.GetOrCreateRequester(new InboundMessage("SM1111", "Some body", "OK", null, "SD2222",
                "+5095551212"));

        resolver.VerifyAll();

        result.RequesterNumber.Should().Be("+15095551212");
    }



}