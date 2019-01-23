﻿using System.Collections.Generic;
using RedWood.Attributes;

namespace RedWood.Test.TestObjects
{
    [TreeNode("Simple Class")]
    public class SimpleClassTest
    {
        [Sublist("Strings")]
        public List<string> strings => new List<string>(){"Test 1", "Test 2", "Test 3"};
        [Sublist("Integers")]
        public List<int> ints => new List<int>(){1,2,3,4,5,6,7};
        [Scalar("Smaller class")]
        public SecondSimpleClass smaller => new SecondSimpleClass();
        [Scalar("Some other kind of scalar")] public string scalar => "This is some data";
    }
}