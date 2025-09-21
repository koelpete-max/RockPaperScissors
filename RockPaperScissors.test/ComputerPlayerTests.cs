using System.Collections.Generic;
using Xunit;

namespace RockPaperScissors.test
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void Computer_UsesRandomSequence()
        {
            var rng = new SequenceRandom(
                (int) Move.Rock, 
                (int) Move.Paper, 
                (int) Move.Scissors, 
                (int) Move.Paper, 
                (int) Move.Rock);
            
            var cpu = new ComputerPlayer("CPU", rng);

            var moves = new List<Move>()
            {
               Move.Rock,
               Move.Paper,
               Move.Scissors,
               Move.Paper,
               Move.Paper
            };
            
            Assert.All(moves, move => Assert.Equal(move, cpu.GetMove()));
        }
    }
}