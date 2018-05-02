using System;
using Open.Core;

namespace Open.Data.Common {
    
    public abstract class TemporalDbRecord : RootObject {

        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;

        public DateTime ValidFrom {
            get => GetMinValue(ref validFrom, ref validTo);
            set => validFrom = value;
        }

        public DateTime ValidTo {
            get => GetMaxValue(ref validTo, ref validFrom);
            set => validTo = value;
        }
    }
}
