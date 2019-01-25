using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using RedWood.Attributes;
using RedWood.Utilities;

namespace RedWood
{
    class TreeListHelper
    {
        public List<OmniNode> Nodes = new List<OmniNode>();
        private TreeList treeList;

        public TreeListHelper(TreeList treeList)
        {
            try
            {
                this.treeList = treeList;
                if (treeList.Columns.FirstOrDefault(c => c.FieldName == "Id") == null)
                {
                    var column = new TreeListColumn();
                    column.FieldName = "Id";
                    treeList.Columns.Add(column);
                }
                if (treeList.Columns.FirstOrDefault(c => c.FieldName == "Data") == null)
                {
                    var column = new TreeListColumn();
                    column.FieldName = "Data";
                    treeList.Columns.Add(column);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error while creating helper:{ex}");
            }
        }

        public void CreateWithAttributes(object o, OmniNode parent = null, bool rootLoaded = false)
        {
            try
            {
                OmniNode root;
                if (!rootLoaded)
                    root = AppendNode(o, parent);
                else root = parent;
                GetSublists(o, o.GetType().GetProperties(), root);
                GetScalars(o, o.GetType().GetProperties(), root);
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error while creating nodes:{ex}");
            }
        }

        public RedNode GetNode(TreeListNode treeNode)
        {
            return Nodes.FirstOrDefault(on => on.TreeNode == treeNode)?.RedNode;
        }

        private OmniNode AppendNode(object data, OmniNode parent = null)
        {
            string listValue = Reflection.GetListValue(data);
            OmniNode output = new OmniNode();
            TreeListNode treeListNode = treeList.AppendNode(new[] {listValue}, parent?.TreeNode);
            treeListNode.SetValue("Id", output.Id);
            treeListNode.Tag = data;
            RedNode outRedNode = new RedNode(ref data);
            outRedNode.Parent = parent?.RedNode;
            output.RedNode = outRedNode;
            output.TreeNode = treeListNode;
            Nodes.Add(output);
            return output;
        }

        private OmniNode AppendListNode(string listValue, IList data, OmniNode parent)
        {
            OmniNode output = new OmniNode();
            TreeListNode treeListNode = treeList.AppendNode(new object[] { listValue }, parent?.TreeNode);
            treeListNode.SetValue("Id", output.Id);
            treeListNode.Tag = data;
            var objectList = (object) data;
            RedNode outRedNode = new RedNode(ref objectList) {Parent = parent?.RedNode};
            output.RedNode = outRedNode;
            output.TreeNode = treeListNode;
            Nodes.Add(output);
            return output;
        }

        private OmniNode AppendScalarNode(object data, PropertyInfo prop, OmniNode parent)
        {
            OmniNode output = new OmniNode();
            string listValue = Reflection.GetScalarValue(data, prop);
            TreeListNode treeListNode = treeList.AppendNode(new[] { listValue }, parent?.TreeNode);
            treeListNode.SetValue("Id", output.Id);
            treeListNode.Tag = data;
            object value = prop.GetValue(data);
            RedNode outRedNode = new RedNode(ref value);
            outRedNode.Parent = parent?.RedNode;
            output.RedNode = outRedNode;
            output.TreeNode = treeListNode;
            Nodes.Add(output);
            return output;
        }

        private void GetSublists(object o, IList<PropertyInfo> props, OmniNode parent)
        {
            foreach (var prop in props.Where(p => p.IsDefined(typeof(SublistAttribute), false)))
            {
                GetPropList(o, prop, parent);
            }
        }

        private void GetPropList(object o, PropertyInfo prop, OmniNode parent)
        {
            IList objects = (IList) prop.GetValue(o);
            var attribute = (SublistAttribute) Attribute.GetCustomAttribute(prop, typeof(SublistAttribute));
            string listValue = attribute.Name;
            OmniNode listHead = AppendListNode(listValue, objects, parent);
            if (objects == null) return;
            if (objects.Count == 0) return;
            var type = objects[0].GetType();
            if (type.IsDefined(typeof(TreeNodeAttribute), false))
            {
                foreach (var obj in objects)
                {
                    CreateWithAttributes(obj, listHead);
                }
            }
            else
            {
                foreach (var obj in objects)
                {
                    string subListValue = Reflection.GetListValue(obj);
                    AppendNode(obj, listHead);
                }
            }
        }

        private void GetScalars(object o, IList<PropertyInfo> props, OmniNode parent)
        {
            foreach (var prop in props.Where(p => p.IsDefined(typeof(ScalarAttribute),false)))
            {
                var root = AppendScalarNode(o, prop, parent);
                if (prop.PropertyType.IsDefined(typeof(TreeNodeAttribute),false))
                    CreateWithAttributes(prop.GetValue(o), root, true);
            }
        }
    }
}