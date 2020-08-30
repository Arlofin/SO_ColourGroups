using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace SetOperations.Test
{
    [TestClass]
    public class CrossProduct
    {
        [TestMethod]
        public void Cross2By3()
        {
            var set1 = new[] { 1, 2};
            var set2 = new[] { 7, 8, 9 };

            var set1TimesSet2 = SetOperations<int>.CrossProduct(new[] { set1, set2 }).ToArray();
            Assert.AreEqual(6, set1TimesSet2.Length);
            var expected = new[]
            {
                new[] {1, 7},
                new[] {1, 8},
                new[] {1, 9},
                new[] {2, 7},
                new[] {2, 8},
                new[] {2, 9}
            };
            for (int i = 0; i < 6; i++)
            {
                CollectionAssert.AreEqual(expected[i], set1TimesSet2[i]);
            }
        }

        [TestMethod]
        public void Cross0By0()
        {
            var set1 = new int[0];
            var set2 = new int[0];

            var set1TimesSet2 = SetOperations<int>.CrossProduct(new[] { set1, set2 }).ToArray();
            Assert.AreEqual(0, set1TimesSet2.Length);
        }
    }
}
