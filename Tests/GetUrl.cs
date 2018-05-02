using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Open.Aids;

namespace Open.Tests {

    public static class GetUrl {

        public static string ForControllerAction<T>(Expression<Func<T, object>> ex = null) where T : Controller {
            var suffix = typeof(Controller).Name;
            var name = typeof(T).Name;
            var controller = name.Remove(name.IndexOf(suffix, StringComparison.Ordinal));
            var action = GetMember.Name(ex);
            var r = string.IsNullOrEmpty(action) ? $"/{controller}" : $"/{controller}/{action}";
            return r.ToLower();
        }
    }
}
