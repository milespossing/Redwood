using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using RedWood.ExtensionMethods;
using RedWood.Utilities;

namespace RedWood
{
    public class RedNode
    {
        public object Data { get; set; }
        public RedNode Parent { get; set; }
        internal OmniNode OmniNode { get; set; }

        public string ListValue => Reflection.GetListValue(Data);

        public RedNode(ref object data)
        {
            Data = data;
        }

        public void Remove()
        {
            if (Parent.Data.IsList())
            {
                
                ((IList) Parent.Data).Remove(Data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}