using MyFigureArea.Models;

namespace MyFigureAreaTests
{
    [TestClass]
    public class MyTests : PageTest
    {
        [TestMethod]
        public void CheckExceptions()
        {
            Assert.ThrowsException<FormatException>(() => new Circle("-1").CalculateArea());
            Assert.ThrowsException<ArgumentException>(() => new Circle("0").CalculateArea());
            Assert.ThrowsException<Exception>(() => new Circle("aaa").CalculateArea());

            Assert.ThrowsException<FormatException>(() => new Rectangle("-1", "2").CalculateArea());
            Assert.ThrowsException<ArgumentException>(() => new Rectangle("0", "2").CalculateArea());
            Assert.ThrowsException<Exception>(() => new Rectangle("1", "aaa").CalculateArea());

            Assert.ThrowsException<ArgumentException>(() => new Triangle("1", "2", "3").CalculateArea());
            Assert.ThrowsException<ArgumentException>(() => new Triangle("0", "2", "3").CalculateArea());
            Assert.ThrowsException<Exception>(() => new Triangle("-1", "2", "3").CalculateArea());
        }

        [TestMethod]
        public void CheckCalculate()
        {
            Assert.IsTrue(new Circle("1").CalculateArea() == 3.14);
            Assert.IsTrue(new Rectangle("2", "10").CalculateArea() == 20);
            Assert.IsTrue(new Triangle("3", "4", "5").CalculateArea() == 6);
        }
    }
}
