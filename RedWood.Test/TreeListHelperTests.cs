using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using RedWood.Test.TestObjects;

namespace RedWood.Test
{
    [TestFixture]
    public class TreeListHelperTests
    {
        [Test]
        public void GetsCorrectTreeList()
        {
            SimpleClassTest t = new SimpleClassTest();
            TreeListHelper helper = new TreeListHelper(new TreeList());
            TreeListNode node = helper.CreateWithAttributes(t);
        }
    }
}
