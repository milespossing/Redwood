using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedWood.Attributes;

namespace RedWood
{
    public partial class TreeListView : UserControl, ITreeListView
    {
        private TreeListController _controller;

        public TreeListView()
        {
            InitializeComponent();
            _controller = new TreeListController(this);
        }

        void ITreeListView.DisplayObject(object o)
        {
            TreeListHelper helper = new TreeListHelper(treeList1);
            helper.CreateWithAttributes(o);
        }

        public void SetObject(object o)
        {
            _controller.SetObject(o);
        }
    }
}
