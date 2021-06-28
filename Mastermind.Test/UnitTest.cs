using System.Linq;
using Mastermind.Core;
using NUnit.Framework;

namespace Mastermind.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Core.MastermindEngine mstrm = new Core.MastermindEngine(lenghtGame: 6);
            Assert.AreEqual(6, mstrm.GameLenght);
            Assert.AreEqual(4, mstrm.RowLength);
            Assert.AreEqual(6, mstrm.ColorsAmount);

            mstrm.Code = new[]{AttemptColor.Blue,AttemptColor.Red,AttemptColor.Green,AttemptColor.Green};
            var colors = new[]{AttemptColor.Green,AttemptColor.Red,AttemptColor.Magenta,AttemptColor.Green};
            var colors2 = new[]{AttemptColor.Blue,AttemptColor.Red,AttemptColor.Green,AttemptColor.Green};
            var colors3 = new[]{AttemptColor.Magenta,AttemptColor.Red,AttemptColor.Red,AttemptColor.Green};
            var colors4 = new[]{AttemptColor.Red,AttemptColor.Blue,AttemptColor.Green,AttemptColor.Magenta};

            mstrm.SaveAttempt(colors);
            Assert.False(mstrm.Validate());
            mstrm.CalculateHints();
            Assert.AreEqual(2,mstrm.Attempts.Last().CorrectPositionColor);
            Assert.AreEqual(1,mstrm.Attempts.Last().CorrectColor);
            
            mstrm.SaveAttempt(colors2);
            Assert.True(mstrm.Validate());
            mstrm.CalculateHints();
            Assert.AreEqual(4,mstrm.Attempts.Last().CorrectPositionColor);
            Assert.AreEqual(0,mstrm.Attempts.Last().CorrectColor);
            
            mstrm.SaveAttempt(colors3);
            Assert.False(mstrm.Validate());
            mstrm.CalculateHints();
            Assert.AreEqual(2,mstrm.Attempts.Last().CorrectPositionColor);
            Assert.AreEqual(0,mstrm.Attempts.Last().CorrectColor);
            
            mstrm.SaveAttempt(colors4);
            Assert.False(mstrm.Validate());
            mstrm.CalculateHints();
            Assert.AreEqual(1,mstrm.Attempts.Last().CorrectPositionColor);
            Assert.AreEqual(2,mstrm.Attempts.Last().CorrectColor);
            
            mstrm.Code = new[]{AttemptColor.Red,AttemptColor.Green,AttemptColor.Blue,AttemptColor.Yellow};
            var colors5 = new[]{AttemptColor.Green,AttemptColor.Blue,AttemptColor.Green,AttemptColor.Green};
            
            mstrm.SaveAttempt(colors5);
            Assert.False(mstrm.Validate());
            mstrm.CalculateHints();
            Assert.AreEqual(0,mstrm.Attempts.Last().CorrectPositionColor);
            Assert.AreEqual(2,mstrm.Attempts.Last().CorrectColor);
        }

        public void Test2()
        {
            
        }
        
    }
}