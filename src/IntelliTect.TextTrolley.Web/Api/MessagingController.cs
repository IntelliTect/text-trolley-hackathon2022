using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace IntelliTect.TextTrolley.Web.Api;

[Route("api/messaging")]
public class MessagingController : TwilioController
{
    public MessagingController(IMessagingService messagingService)
    {
        MessagingService = messagingService ?? throw new ArgumentNullException(nameof(messagingService));
    }

    private IMessagingService MessagingService { get; }

    [HttpPost("receivemessage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TwiMLResult>> ReceiveMessage(SmsRequest inboundRequest)
    {
        var inboundMessage = new InboundMessage(inboundRequest.MessageSid, inboundRequest.Body,
            inboundRequest.MessageStatus, inboundRequest.OptOutType, inboundRequest.MessagingServiceSid,
            inboundRequest.From);
        var requester = await MessagingService.GetOrCreateRequester(inboundMessage);

        var item = MessagingService.ConvertMessageToListItem(requester, inboundMessage);

        await MessagingService.AddNewListItem(item);

        return Ok(new TwiMLResult(new MessagingResponse()));
    }
}