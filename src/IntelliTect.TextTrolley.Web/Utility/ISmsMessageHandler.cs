﻿namespace IntelliTect.TextTrolley.Web.Utility;

public interface ISmsMessageHandler
{ 
    Task<string> HandleSmsAsync(string message, int userId);

}
