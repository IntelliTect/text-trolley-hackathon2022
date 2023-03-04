using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models
{
  public class ShoppingList
  {
    public int ShoppingListId { get; set; }
    [Required]
    public string RequesterId { get; set; }
    [Required]
    public List<int> ApplicationUserIds { get; set; }
  }
}
