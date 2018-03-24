using System;

namespace Open.Data.Country {
    
    public class CountryDbRecord {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
