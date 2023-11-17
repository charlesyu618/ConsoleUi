using System;

namespace ConsoleUi
{
    public class Gamer
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public bool TryLookup(string email, out string name)
        {
            throw new NotImplementedException();
        }

        public bool AskName()
        {
            throw new NotImplementedException();
        }

        public bool AskRestart(int score)
        {
            const int scoreX = 20;
            const int scoreY = 10;
            const int messageX = 5;
            const int messageY = 11;

            Utility.Write($"Score: {score}", scoreX, scoreY, ConsoleColor.Red, ConsoleColor.White);
            Utility.Write("Game Over! Do you want to restart? (Y/N)", messageX, messageY, ConsoleColor.Red, ConsoleColor.White);

            Utility.WaitFor(out var key, ConsoleKey.Y, ConsoleKey.N);
            return key == ConsoleKey.Y;
        }
    }
}
