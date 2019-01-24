using System;
using System.Linq;
using System.Reflection;
using RedWood.Attributes;

namespace RedWood.Utilities
{
    public static class Reflection
    {
        public static string GetListValue(object o)
        {
            var treeNodeAttribute =
                o.GetType().GetCustomAttributes(typeof(TreeNodeAttribute), true)
                    .FirstOrDefault() as TreeNodeAttribute;

            var listValueAttribute =
                o.GetType().GetProperties()
                    .FirstOrDefault(p => p.IsDefined(typeof(ListValueAttribute),false))
                    ?.GetCustomAttributes(typeof(ListValueAttribute), false)
                    .FirstOrDefault() as ListValueAttribute;

            string listValue;

            if (treeNodeAttribute != null && listValueAttribute != null)
            {
                string title = treeNodeAttribute.ListValue;
                string value = o.GetType().GetProperties()
                    .FirstOrDefault(p => p.IsDefined(typeof(ListValueAttribute), false))
                    ?.GetValue(o).ToString();
                listValue = $"{title}: {value}";
            }
            else if (treeNodeAttribute != null) listValue = treeNodeAttribute.ListValue;
            else if (listValueAttribute != null)
            {
                string title = "";
                if (listValueAttribute.Title != "") title = listValueAttribute.Title + ": ";
                string value = o.GetType().GetProperties()
                    .FirstOrDefault(p => p.IsDefined(typeof(ListValueAttribute), false))
                    ?.GetValue(o).ToString();
                listValue = title + value;
            }
            else listValue = o.ToString();
            return listValue;
        }

        public static string GetScalarValue(object o, PropertyInfo prop)
        {
            try
            {
                var dnAttribute = (ScalarAttribute)Attribute.GetCustomAttribute(prop, typeof(ScalarAttribute));
                object propertyValue = prop.GetValue(o);
                if (propertyValue == null) return dnAttribute + ":";
                string scalarPropertyListString = "";
                if (!propertyValue.GetType().IsDefined(typeof(TreeNodeAttribute), false))
                {
                    scalarPropertyListString = $"{propertyValue.ToString()}";
                }
                return
                    $"{dnAttribute.ValueName}{(dnAttribute.ValueName == null || scalarPropertyListString == "" ? "" : ": ")}{scalarPropertyListString}";
            }
            catch (NullReferenceException e)
            {
                return "";
            }
        }
    }
}