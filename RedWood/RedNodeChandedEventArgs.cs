using System;

namespace RedWood
{
    public class RedNodeChandedEventArgs : EventArgs
    {
        public RedNode Node { get; set; }

        public RedNodeChandedEventArgs(RedNode node)
        {
            Node = node;
        }
    }
}