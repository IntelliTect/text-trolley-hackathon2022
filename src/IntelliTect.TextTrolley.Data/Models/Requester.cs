﻿using System;
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
    public string RequesterName { get; set; }
    [Required]
    public string RequesterNumber { get; set; }
  }
}
