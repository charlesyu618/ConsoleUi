using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace ConsoleUi
{
    public enum Effect
    {
        Normal, // Normal Effect
        Life,   // One more life
        Slower  // Move slower
    }

    public class Fruit
    {
        public Point Location { get; set; }
        public int Value { get; set; }

        public int TypeValue { get; set; }  // To determine the fruit type
        public Effect FruitType { get; set; }



        public void Spawn(Canvas canvas, Snake snake, Score score)
        {

            Location = Utility.GetRandomSafePoint(canvas, snake.Points);

            // judge whether the fruit is special
            Random rd = new Random();
            TypeValue = rd.Next(0, 10);

            if (TypeValue <= 7)
            {
                FruitType = Effect.Normal;  // Current fruit is normal

                if (score.Current <= 10)
                {
                    Value = Random.Shared.Next(1, 10);
                }
                else if (score.Current > 10)
                {
                    Value = Random.Shared.Next(2, 5);
                }

                Utility.Write(Value.ToString(), Location.X, Location.Y, Settings.Fruit.Foreground, Settings.Fruit.Background);
            }
            else if (TypeValue == 8)
            {
                FruitType = Effect.Life;    // One more life
                Value = 1;
                Utility.Write(Value.ToString(), Location.X, Location.Y, ConsoleColor.Red, Settings.Fruit.Background);
            }
            else   // 9
            {
                FruitType = Effect.Slower;  // Move slower
                Value = 1;
                Utility.Write(Value.ToString(), Location.X, Location.Y, ConsoleColor.Green, Settings.Fruit.Background);
                // todo: Change the fruit existence time
            }
        }
    }
}
