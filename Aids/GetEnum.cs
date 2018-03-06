using System;

namespace Open.Aids {

    public static class GetEnum {

        public static int Count<T>() {
            return Safe.Run(() => Enum.GetValues(typeof(T)).Length, -1);
        }
    }
}
