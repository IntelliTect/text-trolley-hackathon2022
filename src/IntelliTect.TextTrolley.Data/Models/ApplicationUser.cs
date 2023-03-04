using Microsoft.AspNetCore.Identity;

namespace IntelliTect.TextTrolley.Data.Models;

#nullable disable

public class ApplicationUser : IdentityUser
{
    public int ApplicationUserId { get; set; }

    [Required]
    public string Name { get; set; }

#nullable restore


}
