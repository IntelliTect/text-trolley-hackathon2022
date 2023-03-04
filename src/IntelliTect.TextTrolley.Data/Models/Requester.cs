using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models;

public class Requester
{
    public int RequesterId { get; set; }

    [Required]
    [ClientValidation(IsRequired = true, MinLength = 2, MaxLength = 100)]
    [MaxLength(100)]
    public required string RequesterName { get; set; }

    [Required]
    [ClientValidation(IsRequired = true, IsPhoneUs = true)]
    [MaxLength(30)]
    public required string RequesterNumber { get; set; }

    public int ActiveShoppingListKey { get; set; }

    [Required]
    [ForeignKey(nameof(ActiveShoppingListKey))]
    public ShoppingList ActiveShoppingList { get; set; } = null!;

}
