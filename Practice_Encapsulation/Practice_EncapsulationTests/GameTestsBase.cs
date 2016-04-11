using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Tests
{
    [TestClass]
    public abstract class GameTestsBase
    {
        protected const int fieldSize = 3;
        protected int[] initialValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        protected Point[] initialLocations = {
            new Point(0, 0),
            new Point(1, 0),
            new Point(2, 0),
            new Point(0, 1),
            new Point(1, 1),
            new Point(2, 1),
            new Point(0, 2),
            new Point(1, 2),
            new Point(2, 2)
        };

        protected int[] shiftOrder = { 1, 2, 5, 8, 7, 6, 3, 1};
        protected int[] shiftedValues = { 0, 2, 5, 1, 4, 8, 3, 6, 7 };
        protected Point[] shiftedLocations = {
            new Point(0, 0),
            new Point(0, 1),
            new Point(1, 0),
            new Point(0, 2),
            new Point(1, 1),
            new Point(2, 0),
            new Point(1, 2),
            new Point(2, 2),
            new Point(2, 1)
        };

        [TestMethod]
        public abstract void TestCreation();

        [TestMethod]
        public abstract void TestShift();
    }
}