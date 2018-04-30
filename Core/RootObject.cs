using System;
using Open.Aids;

namespace Open.Core {
    
    public abstract class RootObject {
        
        //TODO: GetValue method access from 'public' to 'protected internal'
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
