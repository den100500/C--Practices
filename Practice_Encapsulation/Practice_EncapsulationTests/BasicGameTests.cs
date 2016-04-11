using GameBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BasicGameTests : GameTestsBase
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
            for (int i = 0; i < shiftOrder.Length; i++)
                game.Shift(shiftOrder[i]);
            for (int i = 0; i < shiftedValues.Length; i++)
                Assert.AreEqual(shiftedLocations[i], game.GetLocation(i));

            for (int y = 0; y < fieldSize; y++)
                for (int x = 0; x < fieldSize; x++)
                    Assert.AreEqual(shiftedValues[y * fieldSize + x], game[x, y]);
        }
    }
}