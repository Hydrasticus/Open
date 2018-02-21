using System;
using System.Collections.Generic;
using System.Linq;

namespace Open.Aids {

    class SystemEnumerable {

        public static IEnumerable<T> OrderBy<T>(IEnumerable<T> list, Func<T, string> func) {
            return list.OrderBy(func);
        }

        public static IEnumerable<T> Distinct<T>(IEnumerable<T> list) {
            return list.Distinct();
        }

        public static IEnumerable<TTo> Convert<TFrom, TTo>(IEnumerable<TFrom> list, Func<TFrom, TTo> func) {
            return list.Select(func);
        }
    }
}
