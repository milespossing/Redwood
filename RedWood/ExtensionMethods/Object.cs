using System.Collections;
using System.Collections.Generic;

namespace RedWood.ExtensionMethods
{
    public static class Object
    {
        public static bool IsList(this object o)
        {
            if (o == null) return false;
            return o is IList;
        }

        public static bool IsDictionary(this object o)
        {
            if (o == null) return false;
            return o is IDictionary &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
        }
    }
}