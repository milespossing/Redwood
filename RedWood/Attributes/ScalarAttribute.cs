using System;

namespace RedWood.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ScalarAttribute : Attribute
    {
        public string ValueName;
        public ScalarAttribute() { }

        public ScalarAttribute(string attributeName)
        {
            ValueName = attributeName;
        }
    }
}