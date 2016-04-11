using GameCompact;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace Tests
{
    [TestClass]
    public class CompactGameTests : GameTestsBase
    {
        [TestMethod]
        public override void TestCreation()
        {
            Game game = Game.Create(initialValues);
            for (int i = 0; i < initialValues.Length; i++)
                Assert.AreEqual(initialLocations[i], game.GetLocation(i));

            for (int y = 0; y < fieldSize; y++)
                for (int x = 0; x < fieldSize; x++)
                    Assert.AreEqual(initialValues[y * fieldSize + x], game[x, y]);
        }

        [TestMethod]
        public override void TestShift()
        {
            Game game = Game.Create(initialValues);
            GameDecorator decorator = (GameDecorator)game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
            Assert.AreEqual(1, game[1, 0]);
            Assert.AreEqual(new Point(0, 0), game.GetLocation(0));
            Assert.AreEqual(new Point(1, 0), game.GetLocation(1));

            Assert.AreEqual(1, decorator[0, 0]);
            Assert.AreEqual(0, decorator[1, 0]);
            Assert.AreEqual(new Point(0, 0), decorator.GetLocation(1));
            Assert.AreEqual(new Point(1, 0), decorator.GetLocation(0));
        }
    }
}
