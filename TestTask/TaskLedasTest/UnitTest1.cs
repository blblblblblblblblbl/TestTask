using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskLedas;


namespace TaskLedasTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            #region vectorMethodsCheck
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(3, 2, 1);
            Console.WriteLine($"CompareTo works: {v1.X == 1d && v1.Y == 2d && v1.Z == 3d}");
            Assert.IsTrue( v1.X == 1 && v1.Y == 2 && v1.Z == 3);
            Console.WriteLine($"Vector3D.Zero() == (0, 0, 0): { Vector3D.Zero().CompareTo(new Vector3D(0, 0, 0)) == 0}");
            Assert.IsTrue(Vector3D.Zero().CompareTo(new Vector3D(0, 0, 0)) == 0);
            Console.WriteLine($"(1, 2, 3)+(3, 2, 1)==(4,4,4): {(v1+v2).CompareTo(new Vector3D(4,4,4))==0}");
            Assert.IsTrue((v1 + v2).CompareTo(new Vector3D(4, 4, 4)) == 0);
            Console.WriteLine($"(1, 2, 3)-(3, 2, 1)==(-2,0,2): {(v1 - v2).CompareTo(new Vector3D(-2, 0, 2))==0}");
            Assert.IsTrue((v1 - v2).CompareTo(new Vector3D(-2, 0, 2)) == 0);
            Console.WriteLine($"(1, 2, 3)*3==(3,6,9):{(v1 *3).CompareTo(new Vector3D(3,6,9)) == 0}");
            Assert.IsTrue((v1 * 3).CompareTo(new Vector3D(3, 6, 9)) == 0);
            Console.WriteLine($"(1,0,0) magnitude is 1: {new Vector3D(1,0,0).Magnitude()==1}");
            Assert.IsTrue(new Vector3D(1, 0, 0).Magnitude() == 1);
            Console.WriteLine($" normalized form of (5,0,0) is (1,0,0):{new Vector3D(5,0,0).Normalize().CompareTo(new Vector3D(1,0,0))==0}");
            #endregion

            #region intersection check
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
                Vector3D intersection = null;
                Assert.IsTrue(Segment3D.Intersect(seg1, seg2) == null);
            }
            #endregion
        }
    }
}
