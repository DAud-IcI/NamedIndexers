using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcIWare.NamedIndexers.Tests
{
    [TestFixture]
    public class TestClass
    {
        public class ExampleObject
        {
            public int[] _numbers = new[] { 4, 8, 15, 16, 23, 42 };
            public char[] _letters = "Lorem Ipsum".ToCharArray();

            public NamedIndexer<int, int> TheNumbers;
            public NamedIndexer<int, char> Typesetter;
            public NamedGetter<int, long> Double;

            public ExampleObject()
            {
                TheNumbers = new NamedIndexer<int, int>(i => _numbers[i], (i, x) => { _numbers[i] = x; });
                Typesetter = new NamedIndexer<int, char>(i => _letters[i], (i, x) => { _letters[i] = x; });
                Double = new NamedGetter<int, long>(x => 2 * x);
            }
        }

        [Test]
        public void TestNumericAccess()
        {
            var o = new ExampleObject();
            for (int i = 0; i < o._numbers.Length; i++)
                Assert.AreEqual(o._numbers[i], o.TheNumbers[i]);

            var r = new System.Random();
            for (int i = 0; i < o._numbers.Length; i++)
            {
                int orig = o.TheNumbers[i];
                o.TheNumbers[i] = r.Next(100) + 100;
                Assert.AreNotEqual(orig, o.TheNumbers[i]);
                Assert.AreNotEqual(orig, o._numbers[i]);
            }

            for (int i = 0; i < o._numbers.Length; i++)
                Assert.AreEqual(o._numbers[i], o.TheNumbers[i]);
        }

        [Test]
        public void TestCharAccess()
        {
            var o = new ExampleObject();
            for (int i = 0; i < o._letters.Length; i++)
                Assert.AreEqual(o._letters[i], o.Typesetter[i]);
        }

        [Test]
        public void TestCustomGetter()
        {
            var o = new ExampleObject();
            for (int i = 0; i < 10; i++)
                Assert.AreEqual(i * 2, o.Double[i]);
        }
    }
}
