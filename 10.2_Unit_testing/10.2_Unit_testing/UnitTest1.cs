using static _10._2_Unit_testing._10_Unit_testing;

namespace _10._2_Unit_testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPoint()
        {
            Point point = new Point(3, 4);
            string result = point.ToString();
            Assert.AreEqual("(3,4)", result);
        }

        [TestMethod]
        public void TestPerimeter()
        {
            Point vertex1 = new Point(0, 0);
            Point vertex2 = new Point(0, 3);
            Point vertex3 = new Point(4, 0);

            Triangle t = new Triangle(vertex1, vertex2, vertex3);

            double result = t.Perimeter();

            Assert.AreEqual(12,0, result);
        }

        [TestMethod]
        public void TestSquare()
        {
            Point vertex1 = new Point(0, 0);
            Point vertex2 = new Point(0, 3);
            Point vertex3 = new Point(4, 0);

            Triangle t = new Triangle(vertex1, vertex2, vertex3);

            double result = t.Square();

            Assert.AreEqual(6,0, result);
        }
    }
}