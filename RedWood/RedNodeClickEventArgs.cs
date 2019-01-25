using System;
using System.Windows.Forms;

namespace RedWood
{
    public class RedNodeClickEventArgs : MouseEventArgs
    {
        public RedNode RedNode { get; set; }

        public RedNodeClickEventArgs(RedNode n, MouseEventArgs e) : base(e.Button,e.Clicks,e.X,e.Y,e.Delta)
        {
            RedNode = n;
        }

        public RedNodeClickEventArgs(MouseButtons button, int clicks, int x, int y, int delta) : base(button, clicks, x, y, delta)
        {
        }
    }
}