using System;
namespace RockPaperScissors
{
	public interface IPlayer
	{
		string Name { get; }
		Move GetMove();
	}
}

