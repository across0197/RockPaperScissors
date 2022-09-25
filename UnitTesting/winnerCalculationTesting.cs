using NUnit.Framework;
using System;

namespace UnitTesting
{
    public class winnerCalculationTesting
    {
       [Test]
       public void winnerCalculation_Working()
       {
            string testUserChoice = "scissors";
            string testComputerChoice = "paper";

            string testResult = RockPaperScissors.Globals.calculateWinner(testUserChoice, testComputerChoice);

            Assert.That(testResult, Is.EqualTo(RockPaperScissors.Globals.winResult));
       }

       [Test]
       public void drawCalculation_Wokring()
       {
            string testUserChoice = "rock";
            string testComputerChoice = "rock";

            string testResult = RockPaperScissors.Globals.calculateWinner(testUserChoice, testComputerChoice);

            Assert.That(testResult, Is.EqualTo(RockPaperScissors.Globals.drawResult));
        }
    }
}