using System;
using System.Linq.Expressions;

namespace Open.Aids {

    public class GetMember {
        
        public static string Name<T>(Expression<Func<T, object>> ex) {
            return name(ex.Body);
        }

        public static string Name<T>(Expression<Action<T>> ex) {
            return name(ex.Body);
        }

        private static string name(Expression ex) {
            var member = ex as MemberExpression;
            var method = ex as MethodCallExpression;
            var operand = ex as UnaryExpression;
            if (!(member is null)) return name(member);
            if (!(method is null)) return name(method);
            if (!(operand is null)) return name(operand);
            return string.Empty;
        }

        private static string name(MemberExpression ex) {
            return ex?.Member.Name ?? string.Empty;
        }

        private static string name(MethodCallExpression ex) {
            return ex?.Method.Name ?? string.Empty;
        }

        private static string name(UnaryExpression ex) {
            var member = ex?.Operand as MemberExpression;
            var method = ex?.Operand as MethodCallExpression;
            if (!(member is null)) return name(member);
            if (!(method is null)) return name(method);
            return string.Empty;
        }
    }
}