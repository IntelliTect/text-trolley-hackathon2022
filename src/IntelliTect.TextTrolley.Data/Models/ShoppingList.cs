using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models
{
  internal class ShoppingList
  {
    public int ShoppingListId { get; set; }
    public string RequesterId { get; set; }
    public List<int> ApplicationUserIds { get; set; }
  }
}
