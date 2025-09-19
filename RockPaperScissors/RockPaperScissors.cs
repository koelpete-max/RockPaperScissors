using System;
namespace RockPaperScissors
{
    public static class RockPaperScissors
    {
        public static Result GetResult(Move p1, Move p2)
        {
            if (p1 == p2)
            {
                return Result.Draw;
            }

            return ((int)p1 - (int)p2 + 3) % 3 == 1 ? Result.Player1Wins : Result.Player2Wins;
        }

        public static bool TryParseMove(string? s, out Move move)
        {
            move = Move.Rock;

            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            s = s.Trim().ToLowerInvariant();

            switch (s) 
            {
                case "r" : 
                case "rock" :
                    move = Move.Rock;
                    break;
                case "p" :
                case "paper" :
                    move = Move.Paper;
                    break;
                case "s" :                
                case "scissor" :
                case "scissors" :
                    move = Move.Scissors;
                    break;
                default:
                    return false;
            }

            return true;
        }

        public static Move CounterOf(Move m) => m switch
        {
            Move.Rock => Move.Paper,
            Move.Paper => Move.Scissors,
            _ => Move.Rock
        };
    }
}

