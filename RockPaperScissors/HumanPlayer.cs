using System;
namespace RockPaperScissors
{
    public sealed class HumanPlayer(string name) : IPlayer
    {
        public string Name { get; } = name;

        public Move GetMove()
        {
            while (true)
            {
                Console.Write($"{Name}, enter your move (r/p/s): ");
                var input = Console.ReadLine();
                if (RockPaperScissors.TryParseMove(input, out var m))
                {
                    return m;
                }
                Console.WriteLine("Invalid input. Please type r, p, or s.");
            }
        }
    }
}

