using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedWood.Test.TestObjects;

namespace RedWood.Test.Forms
{
    public partial class Form1 : Form
    {
        SimpleClassTest c = new SimpleClassTest();
        public Form1()
        {
            InitializeComponent();
            treeListView1.SetObject(c);
        }
    }
}
