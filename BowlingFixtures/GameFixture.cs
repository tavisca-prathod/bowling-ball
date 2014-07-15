using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace BowlingFixtures
{
    [TestClass]
    public class GameFixture
    {
        //Specifications
        //1. Invalid number of pins in Roll one.
        //2. Invalid number of pins in Roll two.
        //3. Invalid total number of pins.


        [TestMethod]
        public void InvalidNumberOfPinsInRollOne()
        {
            Game bowlingGame = new Game();
            int score = 0;
            try {
                bowlingGame.Roll(12);
            }
            catch(Exception ex) {
                score = bowlingGame.GetScore();
                Assert.IsTrue(score==-1,"Test Passed");
            }
        }

        [TestMethod]
        public void ValidNumberOfPinsWithTwoRolls() {
            Game bowlingGame = new Game();
            bowlingGame.Roll(10);
            bowlingGame.Roll(7);
            bowlingGame.Roll(3);
            Assert.IsTrue(bowlingGame.GetScore()==30,"Test Passed");
        }

        [TestMethod]
        public void InvalidNumberOfPinsInRollTwo()
        {
            Game bowlingGame = new Game();
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(0);
            bowlingGame.Roll(9);
            bowlingGame.Roll(0);
            bowlingGame.Roll(0);
            Assert.IsTrue(bowlingGame.GetScore()==19,"Test Passed``");
        }

        [TestMethod]
        public void AllStrike() {
            Game bowlingGame = new Game();
            for (int i = 1; i <= 9;i++ )
            {
                bowlingGame.Roll(10);
            }
            bowlingGame.Roll(7);
            bowlingGame.Roll(2);
            Assert.IsTrue(bowlingGame.GetScore() == 265, "Test Passed");
        }

        [TestMethod]
        public void GeneratRolls()
        {
            Game game = new Game();
            game.Roll(1);
            game.Roll(9);

            game.Roll(1);
            game.Roll(0);

            game.Roll(3);
            game.Roll(7);

            game.Roll(2);
            game.Roll(0);

            game.Roll(5);
            game.Roll(5);

            game.Roll(3);
            game.Roll(0);

            game.Roll(7);
            game.Roll(3);

            game.Roll(4);
            game.Roll(0);

            game.Roll(9);
            game.Roll(0);

            game.Roll(0);
            game.Roll(1);
            Assert.IsTrue(game.GetScore() == 70, "Test Passed");
        }

    }
}
