using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace IntelliTect.TextTrolley.Web.Api;

[Route("api/messaging")]
[AllowAnonymous]
public class MessagingController : TwilioController
{
    public MessagingController(ISmsMessageHandler messageHandler)
    {
        MessageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
    }

    private ISmsMessageHandler MessageHandler { get; }

    [HttpPost("receivemessage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<TwiMLResult> ReceiveMessage(SmsRequest inboundRequest)
    {
        var inboundMessage = new InboundMessage(
            inboundRequest.MessageSid,
            inboundRequest.Body,
            inboundRequest.MessageStatus,
            inboundRequest.OptOutType,
            inboundRequest.MessagingServiceSid,
            inboundRequest.From
        );

        var response = await MessageHandler.HandleSmsAsync(inboundMessage);

        var reply = new MessagingResponse();

        reply.Message(body: response, to: inboundRequest.From);

        var result = new TwiMLResult(reply);
        return result;
    }
}
