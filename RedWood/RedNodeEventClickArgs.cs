using System;
using System.Windows.Forms;

namespace RedWood
{
    public class RedNodeEventClickArgs : MouseEventArgs
    {
        public Node Node { get; set; }

        public RedNodeEventClickArgs(Node n, MouseEventArgs e) : base(e.Button,e.Clicks,e.X,e.Y,e.Delta)
        {
            Node = n;
        }

        public RedNodeEventClickArgs(MouseButtons button, int clicks, int x, int y, int delta) : base(button, clicks, x, y, delta)
        {
        }
    }
}