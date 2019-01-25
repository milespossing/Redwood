using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using RedWood.Attributes;

namespace RedWood
{
    public delegate void RedNodeClickEventHandler(object sender, RedNodeClickEventArgs e);

    public delegate void RedNodeChandedEventHandler(object sender, RedNodeChandedEventArgs e);

    public partial class TreeListView : XtraUserControl
    {
        private object current;
        private TreeListHelper helper;

        public RedNode SelectedRedNode => helper.GetNode(treeList1.FocusedNode);
        public List<RedNode> AllNodes => helper.Nodes.Select(n => n.RedNode).ToList();

        public TreeListView()
        {
            InitializeComponent();
        }

        public void SetObject(object o)
        {
            try
            {
                current = o;
                helper = new TreeListHelper(treeList1);
                helper.CreateWithAttributes(o);
                var node = helper.Nodes.FirstOrDefault(n => (Guid) n.TreeNode.GetValue("Id") == helper.Nodes[7].Id);
                var parent = (IList) helper.Nodes[1].RedNode.Data;
                var childParent = (IList)helper.Nodes[2].RedNode.Parent.Data;
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error while setting object:{ex}");
            }
        }

        public void UpdateObject()
        {
            try
            {
                treeList1.Nodes.Clear();
                SetObject(current);
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Error while updating object:{ex}");
            }
        }

        public event RedNodeClickEventHandler NodeClick;
        public event RedNodeChandedEventHandler NodeChanged;

        private void treeList1_RowClick(object sender, RowClickEventArgs e)
        {
            var node = helper.GetNode(e.Node);
            NodeClick?.Invoke(this, new RedNodeClickEventArgs(node, e));
        }

        private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void TreeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            var node = helper.GetNode(e.Node);
            NodeChanged?.Invoke(this,new RedNodeChandedEventArgs(node));
        }
    }
}
