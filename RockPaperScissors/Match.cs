namespace RockPaperScissors
{
    public static class Match
    {
        public static Result Play(IPlayer p1, IPlayer p2)
        {
            var m1 = p1.GetMove();
            Thread.Sleep(1000);
            var m2 = p2.GetMove();
            
            Console.WriteLine($"{p1.Name}: {m1}  vs  {p2.Name}: {m2}");
            var result = RockPaperScissors.GetResult(m1, m2);
            
            Console.WriteLine(result switch
            {
                Result.Draw => "Result: Draw",
                Result.Player1Wins => $"Result: {p1.Name} wins",
                _ => $"Result: {p2.Name} wins"
            });

            // Feed history to any learning players
            if (p1 is LearningComputerPlayer l1)
            {
                l1.ObserveOpponent(m2);
            }

            if (p2 is LearningComputerPlayer l2)
            {
                l2.ObserveOpponent(m1);
            }

            return result;
        }
    }
}

