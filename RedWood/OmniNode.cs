using System;
using DevExpress.XtraTreeList.Nodes;

namespace RedWood
{
    class OmniNode
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TreeListNode TreeNode { get; set; }

        private Node _node;
        public Node Node
        {
            get => _node;
            set
            {
                _node = value;
                _node.OmniNode = this;
            }
        }
    }
}