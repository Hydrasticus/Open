using System;
using Open.Aids;

namespace Open.Core {
    
    public abstract class RootObject {
        
        //TODO: make getValue methods protected internal
        public string getValue(ref string field, string value) {
            if (string.IsNullOrWhiteSpace(field)) field = (value ?? string.Empty).Trim();
            return field;
        }

        public T getMinValue<T>(ref T field, ref T value) where T : IComparable {
            ToTheSequence.OfGrowing(ref field, ref value);
            return field;
        }

        public T getMaxValue<T>(ref T field, ref T value) where T : IComparable {
            ToTheSequence.OfGrowing(ref value, ref field);
            return field;
        }

        public virtual bool Contains(string searchString) {
            if (string.IsNullOrEmpty(searchString)) return true;
            searchString = searchString.ToLower();
            var values = GetClass.ReadWritePropertyValues(this);
            foreach (var value in values) {
                if (value.ToString().ToLower().Contains(searchString)) return true;
            }

            return false;
        }
    }
}