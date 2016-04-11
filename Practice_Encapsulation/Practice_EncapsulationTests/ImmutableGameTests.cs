using GameImmutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Tests
{
    [TestClass]
    public class ImmutableGameTests : GameTestsBase
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
            Game originalGame = Game.Create(initialValues);
            Game game = originalGame.Shift(1);

            Assert.AreEqual(0, originalGame[0, 0]);
            Assert.AreEqual(1, originalGame[1, 0]);
            Assert.AreEqual(new Point(0, 0), originalGame.GetLocation(0));
            Assert.AreEqual(new Point(1, 0), originalGame.GetLocation(1));

            Assert.AreEqual(1, game[0, 0]);
            Assert.AreEqual(0, game[1, 0]);
            Assert.AreEqual(new Point(0, 0), game.GetLocation(1));
            Assert.AreEqual(new Point(1, 0), game.GetLocation(0));
        }
    }
}