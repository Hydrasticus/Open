using System;

namespace Open.Data {
    public class IsoCountry {
        public IsoCountry() { }
        public IsoCountry(string id, string name, string code, DateTime? validFrom = null, DateTime? validTo = null) {
            ID = id;
            Name = name;
            Code = code;
            ValidFrom = validFrom ?? DateTime.MinValue;
            ValidTo = validTo ?? DateTime.MaxValue;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Alpha3Code => ID;
        public string Alpha2Code => Code;
    }
}
