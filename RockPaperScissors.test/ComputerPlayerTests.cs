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
            Assert.Equal(Move.Rock, cpu.GetMove());
            Assert.Equal(Move.Paper, cpu.GetMove());
            Assert.Equal(Move.Scissors, cpu.GetMove());
            Assert.Equal(Move.Paper, cpu.GetMove());
            Assert.Equal(Move.Rock, cpu.GetMove());
        }
    }
}