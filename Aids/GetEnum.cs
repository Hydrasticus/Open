using System;

namespace Open.Aids {

    public static class GetEnum {

        public static int Count<T>() {
            return Enum.GetValues(typeof(T)).Length;
        }
    }
}
