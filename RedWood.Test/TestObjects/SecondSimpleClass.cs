using RedWood.Attributes;

namespace RedWood.Test.TestObjects
{
    [TreeNode("Sub class")]
    public class SecondSimpleClass
    {
        [Scalar("String Value")]
        public string val => "simple string value";
    }
}