using System.Text.RegularExpressions;

namespace RockPaperScissors
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Let's play Rock–Paper–Scissors (Player vs Computer / Computer vs Player) — with learning CPU");
            Console.WriteLine("Have fun!!");

            var rng = new SystemRandom();
            var human = new HumanPlayer("Player");
            var cpu = new LearningComputerPlayer("Computer", rng, memoryWindow: 50);

            var gameNumber = 1;

            while (true)
            {
                Console.WriteLine($"=== Game {gameNumber} ===");
                if (gameNumber % 2 == 1)
                {
                    Console.WriteLine("Mode: Player vs Computer");
                    Match.Play(human, cpu);
                }
                else
                {
                    Console.WriteLine("Mode: Computer vs Player");
                    Match.Play(cpu, human); //, revealP1Immediately: true);
                }

                Console.Write("Play another game? (y/n): ");
                var cont = Console.ReadLine()?.Trim().ToLowerInvariant();
                if (cont != "y" && cont != "yes")
                {
                    break;
                }
                gameNumber++;
                Console.WriteLine();
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}