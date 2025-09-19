namespace RockPaperScissors
{
    public sealed class LearningComputerPlayer(string name, IRandom rng, int memoryWindow = 50) : IPlayer
    {
        public string Name { get; } = name;
        
        private readonly Dictionary<Move, int> _hist = new()
        {
            { Move.Rock, 0 },
            { Move.Paper, 0 },
            { Move.Scissors, 0 }
        };
        
        private readonly int _memory = Math.Max(0, memoryWindow); // window size (0 = unlimited)

        private readonly Queue<Move> _lastMoves = new();

        public void ObserveOpponent(Move opp)
        {
            _hist[opp]++;
            if (_memory <= 0)
            {
                return;
            }

            _lastMoves.Enqueue(opp);
            if (_lastMoves.Count <= _memory)
            {
                return;
            }

            var old = _lastMoves.Dequeue();
            _hist[old]--;
        }

        public Move GetMove()
        {
            // If no history, pick uniformly at random
            var total = _hist[Move.Rock] + _hist[Move.Paper] + _hist[Move.Scissors];
            if (total == 0)
            {
                return (Move)rng.Next(3);
            }

            // Find most frequent opponent move
            var max = Math.Max(_hist[Move.Rock], Math.Max(_hist[Move.Paper], _hist[Move.Scissors]));
            var candidates = new List<Move>();

            if (_hist[Move.Rock] == max)
            {
                candidates.Add(Move.Rock);
            }

            if (_hist[Move.Paper] == max)
            {
                candidates.Add(Move.Paper);
            }

            if (_hist[Move.Scissors] == max)
            {
                candidates.Add(Move.Scissors);
            }

            var pick = candidates[rng.Next(candidates.Count)]; // tie-break with RNG
            return RockPaperScissors.CounterOf(pick);
        }
    }
}

