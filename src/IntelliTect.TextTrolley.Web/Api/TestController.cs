using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.TextTrolley.Data.Services;
using IntelliTect.TextTrolley.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;

namespace IntelliTect.TextTrolley.Web.Api;

[Route("api/test")]
[AllowAnonymous]
public class TestController : ControllerBase
{
  
    [HttpPost("receivemessage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TwiMLResult>> ReceiveMessage(SmsRequest inboundRequest)
    {
        var inboundMessage = new InboundMessage(inboundRequest.MessageSid, inboundRequest.Body,
            inboundRequest.MessageStatus, inboundRequest.OptOutType, inboundRequest.MessagingServiceSid,
            inboundRequest.From);



        var reply = new MessagingResponse();

        reply.Message(body: "hello test", to: inboundRequest.From);


        return Ok(new TwiMLResult(new MessagingResponse()));
    }

    


}

