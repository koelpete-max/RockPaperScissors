using System;
namespace RockPaperScissors
{
    public sealed class SystemRandom(int? seed = null) : IRandom
    {
        private readonly Random _rng = seed.HasValue ? new Random(seed.Value) : new Random();
        public int Next(int maxExclusive) => _rng.Next(maxExclusive);
    }
}

