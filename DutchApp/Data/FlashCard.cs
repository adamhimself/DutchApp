﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
  public class FlashCard
  {
    public int Id { get; set; }
    public string Front { get; set; }
    public string Back { get; set; }
    public string SoundRef { get; set; }
  }
}
