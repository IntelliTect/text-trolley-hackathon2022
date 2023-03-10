using Microsoft.AspNetCore.Identity;

namespace IntelliTect.TextTrolley.Data.Models;


public class ApplicationUser : IdentityUser<int>
{
  // public int ApplicationUserId { get; set; }

    [Required] 
    [MaxLength(150)]
    public required string Name { get; set; }
}
