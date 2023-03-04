namespace IntelliTect.TextTrolley.Data.Models;

public record InboundMessage(string MessageSid, string Body, string MessageStatus, string? OptOutType, string MessagingServiceSid, string From);