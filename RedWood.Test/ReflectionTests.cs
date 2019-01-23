using System;
using NUnit.Framework;
using RedWood.Utilities;

namespace RedWood.Test
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void SimpleClassTest()
        {
            var obj = new TestObjects.SimpleClassTest();
            string listValue = Reflection.GetListValue(obj);
            Console.WriteLine(listValue);
            Assert.AreEqual("Simple Class", listValue);
        }

        [Test]
        public void SecondSimpleClass()
        {
            var obj = new TestObjects.SecondSimpleClass();
            string listValue = Reflection.GetListValue(obj);
            Console.WriteLine(listValue);
            Assert.AreEqual("Sub class", listValue);
        }

        [Test]
        public void ThirdSimpleClass()
        {
            var obj = new TestObjects.SimpleThirdClass();
            string listValue = Reflection.GetListValue(obj);
            Console.WriteLine(listValue);
            Assert.AreEqual($"Value: {obj.Random}", listValue);
        }
    }
}