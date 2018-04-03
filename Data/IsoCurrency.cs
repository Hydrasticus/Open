﻿using System;

namespace Open.Data {
    
    public class IsoCurrency {
        
        public IsoCurrency() {}

        public IsoCurrency(string id, string name, string code,
            DateTime? validFrom = null, DateTime? validTo = null) {
            ID = id;
            Name = name;
            Code = code;
            ValidFrom = validFrom ?? DateTime.MinValue;
            ValidTo = validFrom ?? DateTime.MaxValue;
        }
        
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string IsoCurrencySymbol => ID;
        public string CurrencySymbol => Code;
    }
}