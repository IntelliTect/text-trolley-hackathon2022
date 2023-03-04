using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Models
{
  public class Requester
  {
    public int RequesterId { get; set; }
    [Required]
    [ClientValidation(IsRequired = true, MinLength = 2, MaxLength = 100)]
    public string RequesterName { get; set; }
    [Required]
    [ClientValidation(IsRequired = true, IsPhoneUs = true)]
    public string RequesterNumber { get; set; }
  }
}
