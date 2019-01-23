using System;

namespace RedWood.Attributes
{
    [AttributeUsage(AttributeTargets.Class | 
                    AttributeTargets.Struct)]
    public class TreeNodeAttribute : Attribute
    {
        public string ListValue;

        public TreeNodeAttribute()
        {

        }

        public TreeNodeAttribute(string listValue)
        {
            ListValue = listValue;
        }
    }
}