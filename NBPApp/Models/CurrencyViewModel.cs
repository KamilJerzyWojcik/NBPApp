﻿using System;

namespace NBPApp.Models
{
    public class CurrencyViewModel
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public virtual decimal Mid { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
