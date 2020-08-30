using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace SetOperations.Test
{
    [TestClass]
    public class SubSets
    {
        [TestMethod]
        public void SubSetsOf3()
        {
            var set = new[] { 1, 2, 3 };

            var subSetsNeg = SetOperations<int>.SubSets(set, -1).ToArray();
            Assert.AreEqual(0, subSetsNeg.Length);

            var subSets0 = SetOperations<int>.SubSets(set, 0).ToArray();
            Assert.AreEqual(1, subSets0.Length);

            var subSets1 = SetOperations<int>.SubSets(set, 1).ToArray();
            Assert.AreEqual(3, subSets1.Length);

            var subSets2 = SetOperations<int>.SubSets(set, 2).ToArray();
            Assert.AreEqual(3, subSets2.Length);

            var subSets3 = SetOperations<int>.SubSets(set, 3).ToArray();
            Assert.AreEqual(1, subSets3.Length);

            var subSets4 = SetOperations<int>.SubSets(set, 4).ToArray();
            Assert.AreEqual(0, subSets4.Length);
        }

        [TestMethod]
        public void SubSetsOfEmpty()
        {
            var set = new int[0];

            var subSetsNeg = SetOperations<int>.SubSets(set, -1).ToArray();
            Assert.AreEqual(0, subSetsNeg.Length);

            var subSets0 = SetOperations<int>.SubSets(set, 0).ToArray();
            Assert.AreEqual(1, subSets0.Length);

            var subSets1 = SetOperations<int>.SubSets(set, 1).ToArray();
            Assert.AreEqual(0, subSets1.Length);
        }
    }
}
