using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUi
{
    public class Score
    {
        public int Current { get; set; } = 0;

        public int HighScore { get; set; } = 0;

        public int[] HighScores { get; set; } = Array.Empty<int>();

        public void Initialize()
        {
            Current = 0;
        }

        public void GetHighScores(Gamer gamer)
        {
            throw new NotImplementedException();
        }

        public void SaveCurrent(Gamer gamer)
        {
            throw new NotImplementedException();
        }
    }
}
