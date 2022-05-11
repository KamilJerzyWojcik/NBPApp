using System;

namespace NBPApp.Models
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public CurrencyType Type { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public virtual decimal? Mid { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal? Bid { get; set; }
        public decimal? Ask { get; set; }
    }
}
