using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models;

public class ShoppingListItem
{
    public int ShoppingListItemId { get; set; }

    [Required]
    [ClientValidation(IsRequired = true, MaxLength = 1024)]
    public required string Name { get; set; }

    [Required]
    public required string OriginalName { get; set; }

    [Required]
    public int ShoppingListId { get; set; }

    [Required]
    public ShoppingList? ShoppingList { get; set; }

    [Required]
    public bool Purchased { get; set; }

}
