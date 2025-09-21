using Xunit;

namespace RockPaperScissors.test
{

    public class RockPaperScissorsLogicTests
    {
        [Theory]
        [InlineData(Move.Rock, Move.Rock, Result.Draw)]
        [InlineData(Move.Rock, Move.Scissors, Result.Player1Wins)]
        [InlineData(Move.Rock, Move.Paper, Result.Player2Wins)]
        [InlineData(Move.Paper, Move.Rock, Result.Player1Wins)]
        [InlineData(Move.Paper, Move.Scissors, Result.Player2Wins)]
        [InlineData(Move.Scissors, Move.Paper, Result.Player1Wins)]
        [InlineData(Move.Scissors, Move.Rock, Result.Player2Wins)]
        public void GetResult_Works(Move a, Move b, Result expected)
            => Assert.Equal(expected, RockPaperScissors.GetResult(a, b));

        [Theory]
        [InlineData("r", Move.Rock)]
        [InlineData("rock", Move.Rock)]
        [InlineData("Rock", Move.Rock)]
        [InlineData("p", Move.Paper)]
        [InlineData("P", Move.Paper)]
        [InlineData("paper", Move.Paper)]
        [InlineData("s", Move.Scissors)]
        [InlineData("scissors", Move.Scissors)]
        [InlineData("sCissoRs", Move.Scissors)]
        public void TryParseMove_Parses(string input, Move expected)
        {
            Assert.True(RockPaperScissors.TryParseMove(input, out var mv));
            Assert.Equal(expected, mv);
        }

        [Theory]
        [InlineData("")]
        [InlineData("banana")]
        public void TryParseMove_Invalid(string input)
            => Assert.False(RockPaperScissors.TryParseMove(input, out _));
    }
}