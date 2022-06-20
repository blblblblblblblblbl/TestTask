using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskLedas;


namespace TaskLedasTest
{
    [TestClass]
    public class UnitTest1
    {
        private Vector3D v1 = new Vector3D(1, 2, 3);
        private Vector3D v2 = new Vector3D(3, 2, 1);
        [TestMethod]
        public void TestOperators()
        {
            //compare
            Assert.IsTrue(new Vector3D(1, 2, 3) == new Vector3D(1, 2, 3));
            Assert.IsTrue(new Vector3D(1, 2, 3) != new Vector3D(1, 4, 3));
            //(1, 2, 3)+(3, 2, 1)==(4,4,4)
            Assert.IsTrue((v1 + v2) == new Vector3D(4, 4, 4));
            //(1, 2, 3)-(3, 2, 1)==(-2,0,2)
            Assert.IsTrue((v1 - v2) == new Vector3D(-2, 0, 2));
            //(1, 2, 3)*3==(3,6,9)
            Assert.IsTrue((v1 * 3) == new Vector3D(3, 6, 9));
        }
        [TestMethod]
        public void TestMagnitude()
        {
            Assert.IsTrue(new Vector3D(1, 0, 0).Magnitude() == 1);
        }
        [TestMethod]
        public void TestNormalized()
        {
            Assert.IsTrue(new Vector3D(5, 0, 0).Normalize() == new Vector3D(1, 0, 0));
        }

        [TestMethod]
        public void TestIntersection()
        {
            Assert.IsTrue(new Vector3D(5, 0, 0).Normalize().CompareTo(new Vector3D(1, 0, 0)) == 0);
            {
                Segment3D seg1 = new Segment3D(new Vector3D(-1, -1, -1), new Vector3D(1, 1, 1));
                Segment3D seg2 = new Segment3D(new Vector3D(-1, 1, -1), new Vector3D(1, -1, 1));
                Vector3D intersection = new Vector3D(0, 0, 0);
                Assert.IsTrue(Segment3D.Intersect(seg1, seg2).CompareTo(intersection)==0);
            }
            {
                Segment3D seg1 = new Segment3D(new Vector3D(0, 0, 0), new Vector3D(5, 0, 0));
                Segment3D seg2 = new Segment3D(new Vector3D(0, 1, 0), new Vector3D(5, -4, 0));
                Vector3D intersection = new Vector3D(1, 0, 0);
                Assert.IsTrue(Segment3D.Intersect(seg1, seg2).CompareTo(intersection) == 0);
            }
            {
                Segment3D seg1 = new Segment3D(new Vector3D(2, 2, 2), new Vector3D(1, 1, 1));
                Segment3D seg2 = new Segment3D(new Vector3D(-1, -1, -1), new Vector3D(-5, -1, -1));
                Assert.IsTrue(Segment3D.Intersect(seg1, seg2) == null);
            }
        }
    }
}
