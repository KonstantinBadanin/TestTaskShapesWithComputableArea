using ShapesWithComputableArea;

namespace TestProject2
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestIsARightTriangle()
        {
            var triangle = new Triangle(11, 11, 12, new TriangleAreaComputer());

            var result = triangle.IsARightTriange;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestArea()
        {
            var triangle = new Triangle(1, 1, 1, new TriangleAreaComputer());
            double expected = 0.433;

            var result = triangle.Area;

            Assert.AreEqual(expected, Math.Round(result, 3));
        }
    }

    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void TestArea()
        {
            var circle = new Circle(1, new CircleAreaComputer());
            double expected = 3.1415927;

            var result = circle.Area;

            Assert.AreEqual(expected, Math.Round(result, 7));

            circle = new Circle(1.41, new CircleAreaComputer());
            expected = 6.2458004;

            result = circle.Area;

            Assert.AreEqual(expected, Math.Round(result, 7));
        }
    }
}