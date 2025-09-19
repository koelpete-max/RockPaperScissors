using System;
namespace RockPaperScissors
{
    public sealed class ComputerPlayer(string name, IRandom rng) : IPlayer
    {
        public string Name { get; } = name;
        public Move GetMove() => (Move)rng.Next(3);
    }
}

