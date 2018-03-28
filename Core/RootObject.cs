using System;
using Open.Aids;

namespace Open.Core {
    
    public class RootObject {
        
        protected RootObject() { }
        
        public string GetValue(ref string field, string value) {
            if (string.IsNullOrWhiteSpace(field)) field = (value ?? string.Empty).Trim();
            return field;
        }

        public T GetMinValue<T>(ref T field, ref T value) where T : IComparable {
            ToTheSequence.OfGrowing(ref field, ref value);
            return field;
        }

        public T GetMaxValue<T>(ref T field, ref T value) where T : IComparable {
            ToTheSequence.OfGrowing(ref value, ref field);
            return field;
        }
    }
}