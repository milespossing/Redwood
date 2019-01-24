using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using RedWood.Attributes;

namespace RedWood
{
    public delegate void RedNodeEventClickEvent(object sender, RedNodeEventClickArgs e);

    public partial class TreeListView : XtraUserControl
    {
        private TreeListHelper helper;

        public TreeListView()
        {
            InitializeComponent();
        }

        private void TreeList1OnRowClick(object sender, RowClickEventArgs e)
        {
            
        }

        public void SetObject(object o)
        {
            helper = new TreeListHelper(treeList1);
            helper.CreateWithAttributes(o);
            var node = helper.Nodes.FirstOrDefault(n => (Guid) n.TreeNode.GetValue("Id") == helper.Nodes[7].Id);
        }

        public event RedNodeEventClickEvent NodeClick;

        private void treeList1_RowClick(object sender, RowClickEventArgs e)
        {
            var node = helper.Nodes.FirstOrDefault(n => n.TreeNode.GetValue("Id") == e.Node.GetValue("Id"));
            NodeClick?.Invoke(this, new RedNodeEventClickArgs(node.Node, e));
        }

        private void treeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
