using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using RedWood.Attributes;

namespace RedWood
{
    public class TreeListHelper
    {
        private TreeList treeList;
        private TreeListColumn column => treeList.Columns["col1"];

        public TreeListHelper(TreeList treeList)
        {
            this.treeList = treeList;
        }

        public TreeListNode CreateWithAttributes(object o, TreeListNode parent = null, bool rootLoaded = false)
        {
            var dnAttribute =
                o.GetType().GetCustomAttributes(typeof(TreeNodeAttribute), true).FirstOrDefault() as TreeNodeAttribute;
            string listValue;
            if (dnAttribute != null) listValue = dnAttribute.ListValue;
            else listValue = o.ToString();
            TreeListNode root;
            if (!rootLoaded)
                root = treeList.AppendNode(new[] {listValue, o}, parent);
            else root = parent;
            root.SetValue(column, o.ToString());
            GetSublists(o, o.GetType().GetProperties(), root);
            GetScalars(o, o.GetType().GetProperties(), root);
            return root;
        }

        private void GetSublists(object o, IList<PropertyInfo> props, TreeListNode parent)
        {
            foreach (var prop in props.Where(p => p.IsDefined(typeof(SublistAttribute), false)))
            {
                GetPropList(o, prop, parent);
            }
        }

        private void GetScalars(object o, IList<PropertyInfo> props, TreeListNode parent)
        {
            foreach (var prop in props.Where(p => p.IsDefined(typeof(ScalarAttribute),false)))
            {
                var dnAttribute = (ScalarAttribute) Attribute.GetCustomAttribute(prop, typeof(ScalarAttribute));
                var val = prop.GetValue(o);
                var node = treeList.AppendNode(new[] {$"{dnAttribute.ValueName}: {val}", o}, parent);
                CreateWithAttributes(val, node);
            }
        }

        private void GetPropList(object o, PropertyInfo prop, TreeListNode parent)
        {
            IList objects = (IList) prop.GetValue(o);
            var attribute = (SublistAttribute) Attribute.GetCustomAttribute(prop, typeof(SublistAttribute));
            string listValue = attribute.Name;
            TreeListNode output = treeList.AppendNode(new object[]{listValue, objects}, parent);
            
            foreach (var obj in objects)
            {
                CreateWithAttributes(obj, output);
            }
        }
    }
}