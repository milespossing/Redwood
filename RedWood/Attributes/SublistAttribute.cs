using System;

namespace RedWood.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class SublistAttribute : Attribute
    {
        public string Name;

        public SublistAttribute(string name)
        {
            this.Name = name;
        }
    }
}