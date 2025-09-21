using System.Collections.Generic;
using Xunit;

namespace RockPaperScissors.test
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void Computer_UsesRandomSequence()
        {
            var rng = new SequenceRandom(0, 1, 2, 1, 0);
            var cpu = new ComputerPlayer("CPU", rng);

            var moves = new List<Move>()
            {
               Move.Rock,
               Move.Paper,
               Move.Scissors,
               Move.Paper,
               Move.Rock
            };
            
            Assert.All(moves, move =>
            {
                Assert.Equal(move, cpu.GetMove());
            });
        }
    }
}