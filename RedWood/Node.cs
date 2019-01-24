using System.Reflection;

namespace RedWood
{
    public class Node
    {
        public object Data { get; set; }
        public Node Parent { get; set; }
        internal OmniNode OmniNode { get; set; }
    }
}