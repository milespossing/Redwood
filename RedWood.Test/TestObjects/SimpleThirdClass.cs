using System;
using RedWood.Attributes;

namespace RedWood.Test.TestObjects
{
    public class SimpleThirdClass
    {
        private static Random rnd = new Random();
        [ListValue("Random Value")]
        [Scalar("Random Value")]
        public int Random { get; set; }

        [Scalar]
        public string Scalar => "I'm a random number";

        public SimpleThirdClass()
        {
            Random = rnd.Next(100);
        }
    }
}