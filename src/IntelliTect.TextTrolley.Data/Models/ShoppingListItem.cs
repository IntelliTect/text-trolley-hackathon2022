using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models
{
  internal class ShoppingListItem
  {
    public int ShoppingListItemId { get; set; }
    public string Name { get; set; }
    public int ShoppingListId { get; set; }

  }
}
