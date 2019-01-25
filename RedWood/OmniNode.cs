using System;
using DevExpress.XtraTreeList.Nodes;

namespace RedWood
{
    class OmniNode
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TreeListNode TreeNode { get; set; }

        private RedNode _redNode;
        public RedNode RedNode
        {
            get => _redNode;
            set
            {
                _redNode = value;
                _redNode.OmniNode = this;
            }
        }
    }
}