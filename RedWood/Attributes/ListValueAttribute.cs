using System;

namespace RedWood.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ListValueAttribute : Attribute
    {
        public string Title = "";

        public ListValueAttribute()
        {
        }

        public ListValueAttribute(string title)
        {
            Title = title;
        }
    }
}