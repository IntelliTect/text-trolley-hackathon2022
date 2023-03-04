using IntelliTect.TextTrolley.Data.Models;

namespace IntelliTect.TextTrolley.Web.Utility;

public interface ISmsMessageHandler
{ 
    Task<string> HandleSmsAsync(InboundMessage message);
}
