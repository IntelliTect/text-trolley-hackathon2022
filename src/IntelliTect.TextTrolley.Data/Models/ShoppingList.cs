using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models;

[AllowAnonymous]
public class ShoppingList
{
    public int ShoppingListId { get; set; }

    [Required]
    public Requester Requester { get; set; } = null!;

    [Required]
    public List<ApplicationUser> ApplicationUsers { get; set; } = new();

    public List<ShoppingListItem> Items { get; set; } = new();

    public bool IsComplete { get; set; }

    public bool IsDelivered { get; set; }

}
