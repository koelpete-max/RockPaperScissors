/***
 Acceptance criteria:
   - I can play Player vs Computer              
   - I can play Computer vs Computer         
   - I can play a different game each time
*/
namespace RockPaperScissors
{
    internal static class Program
    {
        private static int _drawCount = 0;
        private static int _playerCount = 0;
        private static int _gameNumber;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Let's play Rock–Paper–Scissors (Player vs Computer / Computer vs Player) — with learning CPU");
            Console.WriteLine("Have fun!!");

            var rng = new SystemRandom();
            var human = new HumanPlayer("Player");
            var cpu = new LearningComputerPlayer("Computer", rng, memoryWindow: 50);

            _gameNumber = 1;

            while (true)
            {
                Console.WriteLine("=== Game {0} ===", _gameNumber);
                if (_gameNumber % 2 == 1)
                {
                    Console.WriteLine("Mode: Player vs Computer");
                    CountResults(Match.Play(human, cpu), Result.Player1Wins);
                }
                else
                {
                    Console.WriteLine("Mode: Computer vs Player");
                    CountResults(Match.Play(cpu, human), Result.Player2Wins);
                }

                Console.Write("Play another game? (y/n): ");
                var cont = Console.ReadLine()?.Trim().ToLowerInvariant();
                if (cont != "y" && cont != "yes")
                {
                    break;
                }
                _gameNumber++;
                Console.WriteLine();
            }

            DisplayResults();
        }

        private static void CountResults(Result result, Result expectedResult)
        {
            if (result == Result.Draw)
            {
                _drawCount++;
            }
            else if (result == expectedResult)
            {
                _playerCount++;
            }
        }

        private static void DisplayResults()
        {
            Console.WriteLine("\n* ============================== *");
            
            Console.WriteLine("* You played {0} time(s)", _gameNumber);
            
            var text1 = _playerCount > 0 ? 
                $"* You won {_playerCount} time(s)" : 
                $"* You lost all against the computer";

            var computerCount = _gameNumber - _playerCount - _drawCount;
            var text2 = computerCount > 0 ?
                    $"* The computer won {computerCount} time(s)" :
                    "* The computer lost all against you";
            
            var text3 = _drawCount > 0 ? $"* Number of draws : {_drawCount}" : "* No draws";
            
            Console.WriteLine(text1);
            Console.WriteLine(text2);
            Console.WriteLine(text3);
            Console.WriteLine("*\n* Thanks for playing!");
            Console.WriteLine("* ============================== *");
        }
    }
}