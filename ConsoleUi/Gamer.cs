using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUi
{
    public class Gamer
    {
        public string Email { get; set; } = default!;

        public string Name { get; set; } = default!;

        public bool TryLookup(string email, out string name)
        {
            throw new NotImplementedException();
        }

        public bool AskName()
        {
            throw new NotImplementedException();
        }

        public bool AskRestart()
        {
            Utility.Write("Game Over! Do you want to restart? (Y/N)", 0, 0, ConsoleColor.Red, ConsoleColor.White);
            Utility.WaitFor(out var key, ConsoleKey.Y, ConsoleKey.N);
            return key == ConsoleKey.Y;
        }

    }
}
